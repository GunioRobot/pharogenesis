testMenuHandlesGetMenu3ItemMark
	| menuHandle menuItemMark |
	menuHandle := interface getMenuHandle: 3.
	menuItemMark := interface getItemMark: menuHandle item: 1.
	self should: [menuItemMark = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 3.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 4.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 5.
	self should: [menuItemMark  = 0 asCharacter].
	menuItemMark := interface getItemMark: menuHandle item: 6.
	self should: [menuItemMark  = 0 asCharacter].

