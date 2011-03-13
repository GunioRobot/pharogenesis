actions
	^ {
		self action: #findMethod 
			withLabel: 'find method...' 
			withKeystroke: $f 
			withIcon: (MenuIcons tryIcons: #(findIcon smallFindIcon)).
		self action: #fileOut withLabel: 'file out'.
		self browseAction.
		self browseHierarchyAction.
		self action: #chaseVars buttonLabel: 'variables' menuLabel: 'chase variables'.
		self action: #inspectInstances withLabel: 'inspect instances'.
		self action: #inspectSubInstances withLabel: 'inspect subinstances'
	}