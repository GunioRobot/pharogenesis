addSoundTrack

	| fileName |
	fileName _ Utilities chooseFileWithSuffixFromList: #('.aif' '.wav')
					withCaption: 'Choose a sound track file'.
	fileName == nil ifTrue: [^ self].
	('*aif' match: fileName) ifTrue:
		[scorePlayer _ SampledSound fromAIFFfileNamed: fileName].
	('*wav' match: fileName) ifTrue:
		[scorePlayer _ SampledSound fromWaveFileNamed: fileName].
