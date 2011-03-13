testEditMenuItemStyle
	| menuHandle menuItemStyle |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemStyle := interface getItemStyle: menuHandle item: self undoMenuItem.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 3.
	self should: [menuItemStyle size  = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 4.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 5.
	self should: [menuItemStyle size = 0].
	menuItemStyle := interface getItemStyle: menuHandle item: 6.
	self should: [menuItemStyle size = 0].

