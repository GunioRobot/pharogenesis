isControlActive
	^ super isControlActive and: [sensor keyboardPressed not]