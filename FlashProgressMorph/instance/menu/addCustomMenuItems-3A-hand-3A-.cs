addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addList: #(
		('progress color...' changeProgressColor:)
		('progress value...' changeProgressValue:))