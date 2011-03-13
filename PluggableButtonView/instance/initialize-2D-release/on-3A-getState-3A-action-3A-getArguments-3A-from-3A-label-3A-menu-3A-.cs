on: anObject getState: getStateSel action: actionSel getArguments: getArgumentsSel from: argsProvidor label: labelSel menu: menuSel

	self initialize.
	self model: anObject.
	getStateSelector := getStateSel.
	actionSelector := actionSel.
	argumentsSelector := getArgumentsSel.
	argumentsProvider := argsProvidor.
	getLabelSelector := labelSel.
	getMenuSelector := menuSel