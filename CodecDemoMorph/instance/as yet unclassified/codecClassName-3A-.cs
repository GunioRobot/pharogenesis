codecClassName: aStringOrSymbol

	| label |
	codecClassName _ aStringOrSymbol asSymbol.
	self removeAllMorphs.
	label _ StringMorph contents: aStringOrSymbol.
	label position: self position + (5@5).
	self addMorph: label.
	label lock: true.
	self extent: label extent + (10@10).
