readSimpleInstrument: instName fromDirectory: orchestraDir
	"SampledInstrument
		readSimpleInstrument: 'oboe'
		fromDirectory: 'Tosh:Sample Library:Orchestra'"

	| sampleSetDir memBefore memAfter sampleSet snd |
	sampleSetDir _ orchestraDir, ':', instName, ' f'.
	memBefore _ Smalltalk garbageCollect.
	sampleSet _ SampledInstrument new readSampleSetFrom: sampleSetDir.
	memAfter _ Smalltalk garbageCollect.
	Transcript show:
		instName, ': ', (memBefore - memAfter) printString,
		' bytes; ', memAfter printString, ' bytes left'; cr.
	AbstractSound soundNamed: instName, '-f' put:
		(snd _ SampledInstrument new allSampleSets: sampleSet).

	"fix slow attacks"
	snd allNotes do: [:n |
		n firstSample: (n findStartPointForThreshold: 1000)].

	^ snd
