createCheckpoint
	"Export a new checkpoint of me using an ImageSegment."

	^self createCheckpointNumber: 
		(self nextFileNameForCheckPoint findTokens: '.') second asNumber.
