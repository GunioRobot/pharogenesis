matchSoundFile
	"Process an AIFF or WAV sound file and generate a sequence of phoneme matches for that file in the Transcript. When done, open an inspector on the resulting collection of phonemes."

	| fileName snd phonemes |
	fileName := Utilities
		chooseFileWithSuffixFromList: #('.aif' '.aiff' '.wav')
		withCaption: 'Sound file?'.
	fileName = #none ifTrue: [^ self inform: 'No sound files.'].

	('*aif*' match: fileName) ifTrue:
		[snd := SampledSound fromAIFFfileNamed: fileName].
	('*wav' match: fileName) ifTrue:
		[snd := SampledSound fromWaveFileNamed: fileName].

	phonemes := recognizer findMatchesFor: snd.
	phonemes collect: [ :p | Transcript show: p name. ].
	phonemes inspect.