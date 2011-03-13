addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

	super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph.
	aMenu addLine.
	aMenu add: 'inspect' target: self action: #inspectInMorphic.
	aMenu add: 'delete' target: self action: #dismissMorph:.