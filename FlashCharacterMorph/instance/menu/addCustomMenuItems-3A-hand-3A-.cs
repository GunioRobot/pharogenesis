addCustomMenuItems: aMenu hand: aHand
	super addCustomMenuItems: aMenu hand: aHand.
	aMenu add:'add project target' translated action: #addProjectTarget.
	aMenu add:'remove project target' translated action: #removeProjectTarget.