addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'startInfection' action: #startInfection.
	aCustomMenu add: 'set atom count' action: #setAtomCount.
	aCustomMenu add: 'show infection history' action: #showInfectionHistory:.
