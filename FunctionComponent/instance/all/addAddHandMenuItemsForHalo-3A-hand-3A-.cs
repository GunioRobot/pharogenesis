addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

	super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph.
	aMenu add: 'add pin' target: self selector: #addPin.
