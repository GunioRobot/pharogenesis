addCustomMenuItems: menu hand: aHandMorph

	super addCustomMenuItems: menu hand: aHandMorph.
	self addStackMenuItems: menu hand: aHandMorph.
	self addPenMenuItems: menu hand: aHandMorph.
	self addPlayfieldMenuItems: menu hand: aHandMorph.

	menu addLine