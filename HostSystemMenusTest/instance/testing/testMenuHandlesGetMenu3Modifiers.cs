testMenuHandlesGetMenu3Modifiers
	| menuHandle menuItemModifiers |
	menuHandle := interface getMenuHandle: 3.
	menuItemModifiers := interface getMenuItemModifiers: menuHandle item: 1.
	self should: [menuItemModifiers size = 1].
	self should: [menuItemModifiers includes: #command].


