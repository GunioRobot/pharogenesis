addGlyph: aGlyph transformation: aMatrix
	glyphs _ glyphs copyWith: (aMatrix -> aGlyph)