testEditMenuItemIconMacOnly
	| menuHandle menuItemIcon |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemIcon := interface getItemIcon: menuHandle item: self undoMenuItem.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 3.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 4.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 5.
	self should: [menuItemIcon  = 0].
	menuItemIcon := interface getItemIcon: menuHandle item: 6.
	self should: [menuItemIcon  = 0].

