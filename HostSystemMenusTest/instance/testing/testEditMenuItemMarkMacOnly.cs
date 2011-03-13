testEditMenuItemMarkMacOnly
	| menuHandle menuItemMark |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemMark := interface getItemMark: menuHandle item: self undoMenuItem.
	self should: [menuItemMark = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 3.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 4.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 5.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 6.
	self should: [menuItemMark  = 0 asCharacter].

