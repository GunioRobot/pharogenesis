testMenuHandlesGetMenu3IsMenuItemEnabled
	| menuHandle menuItemEnabled |
	menuHandle := interface getMenuHandle: 3.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: 1.
	self should: [menuItemEnabled].
	interface enableMenuItem: menuHandle item: 1.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: 1.
	self should: [menuItemEnabled].
	interface disableMenuItem: menuHandle item: 1.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: 1.
	self should: [menuItemEnabled not].
	interface enableMenuItem: menuHandle item: 1.
