font: aFont
	| newTextStyle |
	newTextStyle _ aFont textStyle copy ifNil: [ TextStyle fontArray: { aFont } ].
	textStyle _ newTextStyle.
	text addAttribute: (TextFontChange fontNumber: (newTextStyle fontIndexOf: aFont)).
	paragraph ifNotNil: [paragraph textStyle: newTextStyle]