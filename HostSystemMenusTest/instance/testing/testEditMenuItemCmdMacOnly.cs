testEditMenuItemCmdMacOnly
	| menuHandle menuItemCmd |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemCmd := interface getItemCmd: menuHandle item: self undoMenuItem.
	self should: [menuItemCmd  = $Z].
	menuItemCmd := interface getItemCmd: menuHandle item: 3.
	self should: [menuItemCmd  = $X].
	menuItemCmd := interface getItemCmd: menuHandle item: 4.
	self should: [menuItemCmd  = $C].
	menuItemCmd := interface getItemCmd: menuHandle item: 5.
	self should: [menuItemCmd  = $V].
	menuItemCmd := interface getItemCmd: menuHandle item: 6.
	self should: [menuItemCmd  = 0 asCharacter].

