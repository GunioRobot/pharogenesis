on: anObject getState: getStateSel action: actionSel label: labelSel menu: menuSel

	self initialize.
	self model: anObject.
	getStateSelector := getStateSel.
	actionSelector := actionSel.
	getLabelSelector := labelSel.
	getMenuSelector := menuSel.