addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'set offset' action: #setOffset:.
	aCustomMenu add: 'remove shadow' action: #removeDropShadow.
