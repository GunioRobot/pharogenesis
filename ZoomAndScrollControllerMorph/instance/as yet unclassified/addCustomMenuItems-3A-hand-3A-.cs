addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'change tilt and zoom keys' action: #changeKeys.
	aCustomMenu add: 'run an existing camera script' action: #runAScript.
	aCustomMenu add: 'edit an existing camera script' action: #editAScript.

