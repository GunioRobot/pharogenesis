addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'reveal original morph' action: #revealOriginal.
	aCustomMenu add: 'grab original morph' action: #grabOriginal.
