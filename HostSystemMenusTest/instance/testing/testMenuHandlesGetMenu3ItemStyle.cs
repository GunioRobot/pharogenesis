testMenuHandlesGetMenu3ItemStyle
	| menuHandle menuItemStyle |
	menuHandle := interface getMenuHandle: 3.
	menuItemStyle := interface getItemStyle: menuHandle item: 1.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 3.
	self should: [menuItemStyle size  = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 4.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 5.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 6.
	self should: [menuItemStyle size = 0].

