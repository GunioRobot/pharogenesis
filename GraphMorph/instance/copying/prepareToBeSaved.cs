prepareToBeSaved
	"SmartRefStream will not write any morph that is owned by someone outside the root being written.  (See DataStream.typeIDFor:)  Open Scripts are like that.  Make a private copy of the scriptEditor."

	super prepareToBeSaved.
	lastAcceptedScript ifNotNil: [
		lastAcceptedScript owner ifNotNil: ["open on the screen"
			lastAcceptedScript _ lastAcceptedScript fullCopy setMorph: self.
			"lastAcceptedScript privateOwner: nil" "fullCopy does it"]].
	"lastScriptEditor will not be written out"