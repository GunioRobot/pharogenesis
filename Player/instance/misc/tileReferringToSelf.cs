tileReferringToSelf
	| aTile |
	aTile _ TileMorph new
		setObjectRef: nil "disused parm" actualObject: self;
		typeColor: (ScriptingSystem colorForType: #player).
	aTile enforceTileColorPolicy.
	^ aTile