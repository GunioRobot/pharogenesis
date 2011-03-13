setSlotRefOperator: opSymbol type: opType

	resultType _ opType.
	self color: (TilePadMorph colorForType: opType).
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: #player).
	self addMorphBack: ((TileMorph new setSlotRefOperator: opSymbol asString) typeColor: color)
