addModelMenuItemsTo: aCustomMenu forMorph: aMorph hand: aHandMorph
	aCustomMenu addLine.
	aCustomMenu add: 'whose script is this?' target: self action: #identifyScript
	