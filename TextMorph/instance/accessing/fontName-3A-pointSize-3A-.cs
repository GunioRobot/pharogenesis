fontName: fontName pointSize: fontSize
	| newTextStyle |
	newTextStyle _ ((TextStyle named: fontName asSymbol) ifNil: [ TextStyle default ]) copy.
	newTextStyle ifNil: [self error: 'font ', fontName, ' not found.'].

	textStyle _ newTextStyle.
	text addAttribute: (TextFontChange fontNumber: (newTextStyle fontIndexOfPointSize: fontSize)).
	paragraph ifNotNil: [paragraph textStyle: newTextStyle]