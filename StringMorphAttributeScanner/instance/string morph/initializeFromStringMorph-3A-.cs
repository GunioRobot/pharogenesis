initializeFromStringMorph: aStringMorph
	| style |
	actualFont _ aStringMorph font ifNil: [ TextStyle defaultFont ].
	style _ actualFont textStyle.
	emphasis _ actualFont emphasis.
	fontNumber _ (style fontIndexOf: actualFont) ifNil: [ 1 ].
	textColor _ aStringMorph color.
