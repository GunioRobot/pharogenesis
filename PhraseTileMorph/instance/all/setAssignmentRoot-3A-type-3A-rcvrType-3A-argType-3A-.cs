setAssignmentRoot: opSymbol type: opType rcvrType: rcvrType argType: argType
	resultType _ opType.
	self color: (TilePadMorph colorForType: opType).
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: rcvrType).
	self addMorphBack: ((AssignmentTileMorph new setRoot: opSymbol asString dataType: argType) typeColor: color).
	self addMorphBack: (TilePadMorph new setType: argType)
