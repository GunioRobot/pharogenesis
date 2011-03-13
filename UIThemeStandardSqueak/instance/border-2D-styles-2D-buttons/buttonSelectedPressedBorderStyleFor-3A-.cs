buttonSelectedPressedBorderStyleFor: aButton
	"Return the selected pressed button borderStyle for the given button."

	aButton borderStyle isComposite
		ifTrue: [^aButton borderStyle].
	^(CompositeBorder new width: 1)
		borders: {aButton borderStyle.
				BorderStyle simple
				color: Color red;
				width: 2}