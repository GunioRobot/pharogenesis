addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'clear' translated action: #clear.
	aCustomMenu add: 'pen color' translated action: #setPenColor:.
	aCustomMenu add: 'pen size' translated action: #setPenSize:.
"	aCustomMenu add: 'fill' translated action: #fill:."
