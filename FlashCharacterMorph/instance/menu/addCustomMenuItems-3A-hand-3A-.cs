addCustomMenuItems: aMenu hand: aHand
	super addCustomMenuItems: aMenu hand: aHand.
	aMenu add:'add project target' action: #addProjectTarget.
	aMenu add:'remove project target' action: #removeProjectTarget.