phrase: aPhraseTileMorph
	"Make the receiver be an anonymous editor around aPhraseTileMorph"
	firstTileRow _ 2.
	self addMorphBack: (AlignmentMorph newRow addMorphBack: aPhraseTileMorph).
	self install