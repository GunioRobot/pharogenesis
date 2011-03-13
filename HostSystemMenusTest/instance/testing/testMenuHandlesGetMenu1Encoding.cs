testMenuHandlesGetMenu1Encoding
	| menuHandle menuItemTextEncoding |
	menuHandle := interface getMenuHandle: 1.
	menuItemTextEncoding := interface getMenuItemTextEncoding: menuHandle item: 1.
	self should: [menuItemTextEncoding = 4294967294 ].

