flipAroundY
	bounds _ (bounds origin x @ bounds corner y negated) corner:
				(bounds corner x @ bounds origin y negated).
	glyphs do:[:glyph| glyph flipAroundY]