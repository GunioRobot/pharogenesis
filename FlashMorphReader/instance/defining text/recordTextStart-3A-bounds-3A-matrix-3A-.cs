recordTextStart: id bounds: bounds matrix: matrix

	textOffset _ 0@0.
	textMorph _ FlashTextMorph new.
	textMorph privateBounds: bounds.
	textMorph color: Color black.
	matrix ifNotNil:[textMorph transform: matrix].