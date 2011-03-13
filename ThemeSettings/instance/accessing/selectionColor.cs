selectionColor
	"Answer the value of selectionColor"

	^self autoSelectionColor
		ifTrue: [self derivedSelectionColor]
		ifFalse: [selectionColor ifNil: [Preferences textHighlightColor]]