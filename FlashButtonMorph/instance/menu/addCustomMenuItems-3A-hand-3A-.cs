addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'set custom action' translated action: #addCustomAction.
	aCustomMenu add: 'remove all actions' translated action: #removeActions.
