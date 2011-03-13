addModelItemsToWindowMenu: aMenu 
	
	aMenu addLine.
	aMenu
		add: 'save contents to file...'
		target: self
		action: #saveContentsInFile.
	aMenu
		add: 'reset variables'
		target: self
		action: #initializeBindings.
	aMenu
		addUpdating: #mustDeclareVariableWording
		target: self
		action: #toggleVariableDeclarationMode.
	aMenu
		addUpdating: #acceptDroppedMorphsWording
		target: self
		action: #toggleDroppingMorphForReference