testMenuHandlesNewMenuAppendDeleteItem2

	self testMenuHandlesNewMenuAppend.
	interface deleteMenuItem: secondaryMenu item: 2.
	self should: [(interface countMenuItems: secondaryMenu) = 1].
	self should: [(interface getMenuItemText: secondaryMenu item: 1) = 'one']



	

