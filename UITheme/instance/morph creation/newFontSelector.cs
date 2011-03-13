newFontSelector
	"Answer a new font selector dialog as appropriate to
	the font support present in the image."

	^(Smalltalk hasClassNamed: #FreeTypeFontFamily)
		ifTrue: [FreeTypeFontSelectorDialogWindow new]
		ifFalse: [TextStyleFontSelectorDialogWindow new]