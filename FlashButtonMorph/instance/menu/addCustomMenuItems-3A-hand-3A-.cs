addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'set custom action' action: #addCustomAction.
	aCustomMenu add: 'remove all actions' action: #removeActions.
