addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'clear' action: #clear.
	aCustomMenu add: 'pen color' action: #setPenColor:.
	aCustomMenu add: 'pen size' action: #setPenSize.
	aCustomMenu add: 'fill' action: #fill.
