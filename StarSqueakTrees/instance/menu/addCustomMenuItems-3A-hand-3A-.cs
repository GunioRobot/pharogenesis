addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'set tree depth' translated action: #setTreeDepth.
	aCustomMenu add: 'set tree type' translated action: #setTreeType.
