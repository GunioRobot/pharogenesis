addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'read from file' action: #readFromFile.
	aCustomMenu add: 'grab from screen' action: #grabFromScreen.
