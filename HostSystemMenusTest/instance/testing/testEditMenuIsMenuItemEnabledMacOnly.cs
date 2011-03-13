testEditMenuIsMenuItemEnabledMacOnly
	| menuHandle menuItemEnabled |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: self undoMenuItem.
	self should: [menuItemEnabled].
	interface enableMenuItem: menuHandle item: self undoMenuItem.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: self undoMenuItem.
	self should: [menuItemEnabled].
	interface disableMenuItem: menuHandle item: self undoMenuItem.
	menuItemEnabled := interface isMenuItemEnabled: menuHandle item: self undoMenuItem.
	self should: [menuItemEnabled not].
	interface enableMenuItem: menuHandle item: self undoMenuItem.
