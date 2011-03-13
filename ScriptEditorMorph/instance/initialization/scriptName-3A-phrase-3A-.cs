scriptName: aScriptName phrase: aPhraseTileMorph
	"Make the receiver be an anonymous editor around aPhraseTileMorph"
	scriptName _ aScriptName.
	self addMorphFront: self buttonRowForEditor.
	self updateStatus.
	firstTileRow _ 2.
	self addMorphBack: (AlignmentMorph newRow addMorphBack: aPhraseTileMorph).
	self install