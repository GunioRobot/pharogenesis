testMenuHandlesNewMenuAppendCheckSetItemText
	| string |
	
	string := 'foobartoobar'.
	self testMenuHandlesNewMenuAppend.
	interface setMenuItemText: secondaryMenu item: 2 itemString: string.
	self should: [(interface getMenuItemText: secondaryMenu item: 2) = string].



	

