addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
"template..."
	aCustomMenu addLine.
	aCustomMenu add: 'edit label...' action: #relabel..
