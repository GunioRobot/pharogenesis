string: aString fontName: aName size: aSize

	self contentsWrapped: aString.
	textStyle _ (TextStyle named: aName asSymbol) copy.
	textStyle ifNil: [self halt: 'Error: font ', aName, ' not found.'].
	text addAttribute: (TextFontChange fontNumber: (textStyle fontIndexOfSize: aSize))
