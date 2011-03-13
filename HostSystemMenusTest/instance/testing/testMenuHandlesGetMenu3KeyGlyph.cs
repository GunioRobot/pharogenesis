testMenuHandlesGetMenu3KeyGlyph
	| menuHandle menuItemKeyGlyph |
	menuHandle := interface getMenuHandle: 3.
	menuItemKeyGlyph := interface getMenuItemKeyGlyph: menuHandle item: 1.
	self should: [menuItemKeyGlyph = 0].

