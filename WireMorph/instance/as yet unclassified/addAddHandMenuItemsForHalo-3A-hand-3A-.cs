addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

	super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph.
	aMenu add: 'delete' target: self action: #dismissMorph: