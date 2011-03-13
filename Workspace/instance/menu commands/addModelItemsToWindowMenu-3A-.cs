addModelItemsToWindowMenu: aMenu 
	aMenu addLine.
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
		action: #toggleDroppingMorphForReference.

	aMenu 
		add: 'previous contents...'
		target: self
		selector: #selectPreviousContent