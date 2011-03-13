testMenuHandlesGetMenuTitle
	self should: [(interface getMenuTitle: (interface getMenuHandle: 1)) = ''].
	self should: [(interface getMenuTitle: (interface getMenuHandle: 3)) = 'Edit'].

