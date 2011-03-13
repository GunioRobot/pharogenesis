selectionColor: aColor
	"Set the colour to use for the text selection."

	aColor
		ifNil: [self removeProperty: #selectionColor]
		ifNotNil: [self setProperty: #selectionColor toValue: aColor].
	self textMorph ifNotNilDo: [:t | t selectionColor: aColor]