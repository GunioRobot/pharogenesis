on: anObject getState: getStateSel action: actionSel getArguments: getArgumentsSel from: argsProvidor label: labelSel menu: menuSel

	self initialize.
	self model: anObject.
	getStateSelector _ getStateSel.
	actionSelector _ actionSel.
	argumentsSelector _ getArgumentsSel.
	argumentsProvider _ argsProvidor.
	getLabelSelector _ labelSel.
	getMenuSelector _ menuSel