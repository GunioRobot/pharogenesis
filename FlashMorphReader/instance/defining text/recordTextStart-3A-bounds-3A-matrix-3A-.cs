recordTextStart: id bounds: bounds matrix: matrix

	textOffset := 0@0.
	textMorph := FlashTextMorph new.
	textMorph privateBounds: bounds.
	textMorph color: Color black.
	matrix ifNotNil:[textMorph transform: matrix].