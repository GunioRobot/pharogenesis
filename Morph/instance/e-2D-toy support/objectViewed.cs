objectViewed
	"Answer the morph associated with the player that the structure the receiver currently finds itself within represents."

	^ (self outermostMorphThat: [:o | o isKindOf: Viewer orOf: ScriptEditorMorph]) objectViewed