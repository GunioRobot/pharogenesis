savePhonemes
	"Save the current phoneme set in a file."

	| fname refStream |
	fname _ FillInTheBlank request: 'Phoneme file name?'.
	fname isEmpty ifTrue: [^ self].
	((fname endsWith: '.pho') or: [fname endsWith: '.phonemes'])
		ifFalse: [fname _ fname, '.phonemes'].
	refStream _ SmartRefStream fileNamed: fname.
	refStream nextPut: phonemeRecords.
	refStream close.
