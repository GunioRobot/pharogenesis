savePhonemes
	"Save the current phoneme set in a file."

	| fname refStream |
	fname := FillInTheBlank request: 'Phoneme file name?'.
	fname isEmpty ifTrue: [^ self].
	((fname endsWith: '.pho') or: [fname endsWith: '.phonemes'])
		ifFalse: [fname := fname, '.phonemes'].
	refStream := SmartRefStream fileNamed: fname.
	refStream nextPut: recognizer phonemes.
	refStream close.
