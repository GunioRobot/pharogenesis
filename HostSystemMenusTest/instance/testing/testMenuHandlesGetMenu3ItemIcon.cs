testMenuHandlesGetMenu3ItemIcon
	| menuHandle menuItemIcon |
	menuHandle := interface getMenuHandle: 3.
	menuItemIcon := interface getItemIcon: menuHandle item: 1.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 3.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 4.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 5.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 6.
	self should: [menuItemIcon  = 0].

