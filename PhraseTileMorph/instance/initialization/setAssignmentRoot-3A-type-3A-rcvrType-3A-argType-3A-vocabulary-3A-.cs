setAssignmentRoot: opSymbol type: opType rcvrType: rcvrType argType: argType vocabulary: aVocabulary
	"Add submorphs to make me constitute a setter of the given symbol"

	| anAssignmentTile |
	resultType _ opType.
	self color: (ScriptingSystem colorForType: opType).
	self removeAllMorphs.
	self addMorph: (TilePadMorph new setType: rcvrType).
	anAssignmentTile _ AssignmentTileMorph new rawVocabulary: aVocabulary.
	self addMorphBack: (anAssignmentTile typeColor: color).
	anAssignmentTile setRoot: opSymbol asString dataType: argType.
	anAssignmentTile setAssignmentSuffix: #:.
	self addMorphBack: (TilePadMorph new setType: argType)