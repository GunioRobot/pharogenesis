testMenuHandlesGetMenu1FontID
	| menuHandle menuItemFontID |
	menuHandle := interface getMenuHandle: 1.
	menuItemFontID := interface getMenuItemFontID: menuHandle item: 1.
	self should: [menuItemFontID = 0].

