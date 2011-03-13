readPhonemes
	"Read a previously saved phoneme set from a file."

	| fname s newPhonemes |
	fname _ Utilities
		chooseFileWithSuffixFromList: #('.pho' '.phonemes')
		withCaption: 'Phoneme file?'.
	fname == nil ifTrue: [^ self].
	fname ifNil: [^ self].

	s _ FileStream readOnlyFileNamed: fname.
	newPhonemes _ s fileInObjectAndCode.
	s close.
	phonemeRecords _ newPhonemes.
