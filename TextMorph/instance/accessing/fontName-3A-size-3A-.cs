fontName: fontName size: fontSize
	| newTextStyle |
	newTextStyle _ (TextStyle named: fontName asSymbol) copy.
	newTextStyle ifNil: [self halt: 'Error: font ', fontName, ' not found.'].

	textStyle _ newTextStyle.
	text addAttribute: (TextFontChange fontNumber: (newTextStyle fontIndexOfSize: fontSize)).
	paragraph ifNotNil: [paragraph textStyle: newTextStyle]