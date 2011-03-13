setAngleToOperator: opSymbol type: opType rcvrType: rcvrType argType: argType
	"Set the operator, type, receiver type, and argument type for the phrase"

	| aTileMorph |

	resultType _ opType.
	opType ifNotNil: [self color: (ScriptingSystem colorForType: opType)].
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: rcvrType).
	aTileMorph _ KedamaAngleToTile new adoptVocabulary: self currentVocabulary.
	self addMorphBack: ((aTileMorph setOperator: opSymbol asString) typeColor: color).
	opSymbol numArgs = 1 ifTrue:
		[self addMorphBack: (TilePadMorph new setType: (argType ifNil: [#Object]))]