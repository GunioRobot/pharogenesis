setSlotRefOperator: opSymbol type: opType
	"Set the given symbol as the receiver's slot-reference operator, adding tiles to the receiver appropriately"

	resultType _ opType.
	self color: (ScriptingSystem colorForType: opType).
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: #Player).
	self addMorphBack: ((TileMorph new setSlotRefOperator: opSymbol asString) typeColor: color)
