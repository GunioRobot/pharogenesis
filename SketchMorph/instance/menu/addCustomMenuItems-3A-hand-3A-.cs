addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'choose new graphic...' target: self action: #chooseNewGraphic.
	aCustomMenu add: 'set as background' target: rotatedForm action: #setAsBackground.
	aCustomMenu addUpdating: #roundedCornersString target: self action: #toggleCornerRounding.
	self addPaintingItemsTo: aCustomMenu hand: aHandMorph