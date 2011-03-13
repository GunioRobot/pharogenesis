setOperator: opSymbol type: opType rcvrType: rcvrType argType: argType

	resultType _ opType.
	self color: (TilePadMorph colorForType: opType).
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: rcvrType).
	self addMorphBack: ((TileMorph new setOperator: opSymbol asString) typeColor: color).
	opSymbol numArgs = 1 ifTrue: [
		self addMorphBack: (TilePadMorph new setType: argType)].
