on: anObject getState: getStateSel action: actionSel label: labelSel menu: menuSel

	self model: anObject.
	getStateSelector _ getStateSel.
	actionSelector _ actionSel.
	getLabelSelector _ labelSel.
	getMenuSelector _ menuSel.
	self update: labelSel.
