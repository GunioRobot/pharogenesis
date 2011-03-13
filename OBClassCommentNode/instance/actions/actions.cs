actions
	^ {
		self browseAction.
		self browseHierarchyAction.
		self action: #chaseVars buttonLabel: 'variables' menuLabel: 'chase variables'
	}