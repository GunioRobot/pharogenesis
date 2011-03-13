testMenuHandlesNewMenuAppendCheckSetMenuTitle
	| string |
	
	string := 'foobartoobar'.
	self testMenuHandlesNewMenuAppend.
	interface setMenuTitle: secondaryMenu title: string.
	self should: [(interface getMenuTitle: secondaryMenu) = string].



	

