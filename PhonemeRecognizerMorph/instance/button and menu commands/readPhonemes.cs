readPhonemes
	"Read a previously saved phoneme set from a file."

	| fname s newPhonemes |
	fname := Utilities chooseFileWithSuffixFromList: #('.pho' '.phonemes')
				withCaption: 'Phoneme file?'.
	fname isNil ifTrue: [^self].
	fname ifNil: [^self].
	s := FileStream readOnlyFileNamed: fname.
	newPhonemes := s fileInObjectAndCode.
	s close.
	phonemeRecords := newPhonemes