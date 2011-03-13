setPaletteFor: aLanguageSymbol 
	| prototype formKey form |
	prototype := PaintBoxMorph prototype.
	formKey := ('offPalette' , aLanguageSymbol) asSymbol.
	form := Imports default imports
				at: formKey
				ifAbsent: [Imports default imports
						at: #offPaletteEnglish
						ifAbsent: []].
	form isNil ifFalse: [prototype loadOffForm: form].
	formKey := ('pressedPalette' , aLanguageSymbol) asSymbol.
	form := Imports default imports
				at: formKey
				ifAbsent: [Imports default imports
						at: #pressedPaletteEnglish
						ifAbsent: []].
	form isNil ifFalse: [prototype loadPressedForm: form].
