addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'read file' action: #readDataFromFile.
	aCustomMenu add: 'script' action: #editScript:.
