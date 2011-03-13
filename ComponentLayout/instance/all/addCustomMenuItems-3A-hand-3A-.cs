addCustomMenuItems: menu hand: aHandMorph

	super addCustomMenuItems: menu hand: aHandMorph.
	menu addLine.
	menu add: 'inspect model in morphic' action: #inspectModelInMorphic