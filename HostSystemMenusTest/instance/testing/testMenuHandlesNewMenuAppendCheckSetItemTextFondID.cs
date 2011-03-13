testMenuHandlesNewMenuAppendCheckSetItemTextFondID
	| glyph |
	self testMenuHandlesNewMenuAppend.
	glyph := 16r6C.
	interface setMenuItemKeyGlyph: secondaryMenu item: 2 glyph:  glyph.
	self should: [(interface getMenuItemKeyGlyph: secondaryMenu item: 2) = glyph].
	

	

