testMenuHandlesGetMenu3ItemCmd
	| menuHandle menuItemCmd |
	menuHandle := interface getMenuHandle: 3.
	menuItemCmd := interface getItemCmd: menuHandle item: 1.
	self should: [menuItemCmd  = $Z].
	menuItemCmd := interface getItemCmd: menuHandle item: 3.
	self should: [menuItemCmd  = $X].
	menuItemCmd := interface getItemCmd: menuHandle item: 4.
	self should: [menuItemCmd  = $C].
	menuItemCmd := interface getItemCmd: menuHandle item: 5.
	self should: [menuItemCmd  = $V].
	menuItemCmd := interface getItemCmd: menuHandle item: 6.
	self should: [menuItemCmd  = 0 asCharacter].

