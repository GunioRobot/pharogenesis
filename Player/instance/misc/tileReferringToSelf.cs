tileReferringToSelf
	| aTile |
	aTile _ TileMorph new
		setObjectRef: nil "disused parm" actualObject: self;
		typeColor: (TilePadMorph colorForType: #player).
	self costume presenter coloredTilesEnabled ifFalse: [aTile useUniformTileColor].
	^ aTile