initFromParent:  aProject

	"Written so that Morphic can still be removed."
	world _ (Smalltalk at: #WorldMorph ifAbsent: [^ nil]) new.
	changeSet _ ChangeSet new initialize.
	transcript _ Transcript.  "  -- we need a TranscriptMorph"
	displayDepth _ Display depth.
	parentProject _ aProject