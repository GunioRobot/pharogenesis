addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'open sorter' action: #openSorter.
	aCustomMenu add: 'make controls' action: #makeControls.
	aCustomMenu addLine.