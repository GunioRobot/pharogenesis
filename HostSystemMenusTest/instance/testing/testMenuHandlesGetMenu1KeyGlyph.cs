testMenuHandlesGetMenu1KeyGlyph
	| menuHandle menuItemKeyGlyph |
	menuHandle := interface getMenuHandle: 1.
	menuItemKeyGlyph := interface getMenuItemKeyGlyph: menuHandle item: 1.
	self should: [menuItemKeyGlyph = 0].

