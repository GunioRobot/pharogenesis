setPaletteFor: aLanguageSymbol 
	| prototype formKey form |
	prototype _ PaintBoxMorph prototype.
	formKey _ ('offPalette' , aLanguageSymbol) asSymbol.
	form _ Imports default imports
				at: formKey
				ifAbsent: [Imports default imports
						at: #offPaletteEnglish
						ifAbsent: []].
	form isNil ifFalse: [prototype loadOffForm: form].
	formKey _ ('pressedPalette' , aLanguageSymbol) asSymbol.
	form _ Imports default imports
				at: formKey
				ifAbsent: [Imports default imports
						at: #pressedPaletteEnglish
						ifAbsent: []].
	form isNil ifFalse: [prototype loadPressedForm: form].
