testEditMenuItemsTextMacOnly
	| menuHandle menuItemText |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemText := interface getMenuItemText: menuHandle item: 1.
	self should: [menuItemText  = 'Undo'].
	menuItemText := interface getMenuItemText: menuHandle item: 2.
	self should: [menuItemText  = '-'].
	menuItemText := interface getMenuItemText: menuHandle item: 3.
	self should: [menuItemText  = 'Cut'].
	menuItemText := interface getMenuItemText: menuHandle item: 4.
	self should: [menuItemText  = 'Copy'].
	menuItemText := interface getMenuItemText: menuHandle item: 5.
	self should: [menuItemText  = 'Paste'].
	menuItemText := interface getMenuItemText: menuHandle item: 6.
	self should: [menuItemText  = 'Clear'].

