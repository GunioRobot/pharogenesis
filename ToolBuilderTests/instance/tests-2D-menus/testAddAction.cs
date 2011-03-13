testAddAction
	self assertItemFiresWith: [:spec | spec add: 'Menu Item' action: #fireMenuAction]