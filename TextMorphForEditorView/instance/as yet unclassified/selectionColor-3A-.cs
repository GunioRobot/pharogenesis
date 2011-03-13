selectionColor: aColor
	"Set the colour to use for the text selection."

	aColor
		ifNil: [self removeProperty: #selectionColor]
		ifNotNil: [self setProperty: #selectionColor toValue: aColor].
	paragraph ifNotNilDo: [:p |
		(p respondsTo: #selectionColor:) ifTrue: [
			p selectionColor: aColor]]