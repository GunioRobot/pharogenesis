addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'set channel' action: #setChannel:.
	aCustomMenu add: 'set controller' action: #setController:.
