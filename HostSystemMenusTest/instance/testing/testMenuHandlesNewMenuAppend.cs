testMenuHandlesNewMenuAppend
	|  menuString items |
	menuString := 'Foobar'.
	secondaryMenu := interface newMenu: self notUsedMenuNumber2 menuTitle: menuString.
	interface insertMenu: secondaryMenu beforeID: 0.
	items := OrderedCollection with: (HostSystemMenusMenuItem menuString: 'one')
			with: (HostSystemMenusMenuItem menuString: 'two' keyboardKey: $a).
	interface appendMenu: secondaryMenu menuItems: items.
	self should: [(interface getMenuItemText: secondaryMenu item: 1) = 'one'].
	self should: [(interface getMenuItemText: secondaryMenu item: 2) = 'two'].
	self should: [(interface getItemCmd: secondaryMenu item: 2) = $A].
	self should: [(interface getItemIcon: secondaryMenu item: 1)  = 0].
	self should: [(interface getItemMark: secondaryMenu item: 1)  = 0 asCharacter].
	self should: [(interface getItemStyle: secondaryMenu item: 1) size = 0].



	

