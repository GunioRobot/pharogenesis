addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

	super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph.
	aMenu addLine.
	aMenu add: 'inspect' action: #inspectMorph.
	aMenu add: 'delete' action: #dismissMorph