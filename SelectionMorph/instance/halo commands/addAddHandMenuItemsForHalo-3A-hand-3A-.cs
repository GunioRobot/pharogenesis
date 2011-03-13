addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

	aMenu addLine.
	aMenu add: 'add or remove items' target: self selector: #addOrRemoveItems: argument: aHandMorph.
	^ super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph

