chunkDescriptionFor: id
	"Answer chunk description for id"
	
	^self chunkDescriptions at: id ifAbsent: []