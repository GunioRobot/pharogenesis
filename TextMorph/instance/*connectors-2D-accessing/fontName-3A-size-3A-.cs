fontName: fontName size: fontSize
	| newTextStyle |
	newTextStyle _ ((TextStyle named: fontName asSymbol) ifNil: [ TextStyle default ]) copy.
	textStyle _ newTextStyle.
	text addAttribute: (TextFontChange fontNumber: (newTextStyle fontIndexOfSize: fontSize)).
	paragraph ifNotNil: [paragraph textStyle: newTextStyle]