readLoudAndStaccatoInstrument: instName fromDirectory: orchestraDir
	"SampledInstrument
		readLoudAndStaccatoInstrument: 'oboe'
		fromDirectory: 'Tosh:Sample Library:Orchestra'"

	| sampleSetDir memBefore memAfter loud short snd |
	sampleSetDir _ orchestraDir, ':', instName.
	memBefore _ Smalltalk garbageCollect.
	loud _ SampledInstrument new readSampleSetFrom: sampleSetDir, ' f'.
	short _ SampledInstrument new readSampleSetFrom: sampleSetDir, ' stacc'.
	memAfter _ Smalltalk garbageCollect.
	Transcript show:
		instName, ': ', (memBefore - memAfter) printString,
		' bytes; ', memAfter printString, ' bytes left'; cr.
	AbstractSound soundNamed: instName, '-f&stacc' put:
		(snd _ SampledInstrument new
			allSampleSets: loud;
			staccatoLoudAndSoftSampleSet: short).
	"fix slow attacks"
	snd allNotes do: [:n | n firstSample: (n findStartPointForThreshold: 500)].

	AbstractSound soundNamed: instName, '-f' put:
		(snd _ SampledInstrument new
			allSampleSets: loud).
	"fix slow attacks"
	snd allNotes do: [:n | n firstSample: (n findStartPointForThreshold: 1000)].
