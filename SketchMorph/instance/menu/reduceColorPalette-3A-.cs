reduceColorPalette: evt
	"Let the user ask for a reduced number of colors in this sketch"

	| str nColors |
	str _ FillInTheBlank
		request: 'Please enter a number greater than one.
(note: this cannot be undone, so answer zero
to abort if you need to make a backup first)' translated
		initialAnswer: '256'.
	nColors _ Integer readFrom: (ReadStream on: str).
	(nColors between: 2 and: 256) ifFalse: [^ self].

	originalForm _ originalForm copyWithColorsReducedTo: nColors.
	rotatedForm _ nil.
	self changed