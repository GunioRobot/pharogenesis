addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'pen color' action: #setPenColor:.
	aCustomMenu add: 'pen size' action: #setPenSize:.
	aCustomMenu add: 'fill' action: #fill.
	aCustomMenu add: 'magnification' action: #setMagnification:.
	aCustomMenu add: 'accept' action: #accept.
	aCustomMenu add: 'revert' action: #revert.
