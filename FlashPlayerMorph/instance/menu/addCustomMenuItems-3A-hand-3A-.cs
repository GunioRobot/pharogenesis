addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'open sorter' translated action: #openSorter.
	aCustomMenu add: 'make controls' translated action: #makeControls.
	aCustomMenu addLine.