testMenuHandlesNewMenuAppendDeleteItem

	self testMenuHandlesNewMenuAppend.
	interface deleteMenuItem: secondaryMenu item: 1.
	self should: [(interface countMenuItems: secondaryMenu) = 1].
	self should: [(interface getMenuItemText: secondaryMenu item: 1) = 'two']



	

