actions
	^ {
		self action: #fileOut withLabel: 'file out'.
		self browseAction.
		self browseHierarchyAction.
		self action: #chaseVars buttonLabel: 'variables' menuLabel: 'chase variables'
	}
