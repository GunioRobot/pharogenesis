showEvents: aBool
	"HandMorph showEvents: true"
	"HandMorph showEvents: false"
	ShowEvents _ aBool.
	aBool ifFalse: [ ActiveWorld invalidRect: (0@0 extent: 250@120) ].