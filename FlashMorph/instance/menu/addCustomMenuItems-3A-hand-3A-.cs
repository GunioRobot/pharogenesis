addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addUpdating: #getSmoothingLevel action: #nextSmoothingLevel.
	aCustomMenu add:'show compressed size' translated action: #showCompressedSize.