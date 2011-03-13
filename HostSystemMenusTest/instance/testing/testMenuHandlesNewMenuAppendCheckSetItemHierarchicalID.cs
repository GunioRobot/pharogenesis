testMenuHandlesNewMenuAppendCheckSetItemHierarchicalID

	| menuString items |
	self testMenuHandlesNewMenuAppend.
	menuString := ''.
	subMenu := interface newMenu: self notUsedMenuNumber menuTitle: menuString.
	items := OrderedCollection with: (HostSystemMenusMenuItem menuString: 'three')
			with: (HostSystemMenusMenuItem menuString: 'four' keyboardKey: $b)..
	interface appendMenu: subMenu menuItems: items.
	self should: [(interface getMenuItemText: subMenu item: 1) = 'three'].
	self should: [(interface getMenuItemText: subMenu item: 2) = 'four'].
	self should: [(interface getItemCmd: subMenu item: 2) = $B].
	interface insertMenu: subMenu beforeID: -1.
	interface setMenuItemHierarchicalID: secondaryMenu item: 1 hierID: self notUsedMenuNumber.
	self should: [(interface getMenuItemHierarchicalID: secondaryMenu item: 1) = 5]

	

