addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'open wave editor' action: #openWaveEditor.
	aCustomMenu add: 'read file' action: #readDataFromFile.
