testMenuHandlesNewMenuAppendCheckSetItemModifiers
	| modifiers |
	
	self testMenuHandlesNewMenuAppend.
	modifiers := #( (#command)  (#shift) (#option) (#control) (#nocommand) 
		( #shift #option #control #nocommand)).
	modifiers do: [:m |
			interface setMenuItemModifiers: secondaryMenu item: 2 inModifiers: m.
			self should: [(interface getMenuItemModifiers: secondaryMenu item: 2) = m asSet]]
			


	

