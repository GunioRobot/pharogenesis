phraseTileMorph
	"Answer the phraseTileMorph within the receiver"

	^ ((self entryType == #systemScript) or: [self entryType == #userScript])
		ifTrue:
			[self viewerRow findA: PhraseTileMorph]
		ifFalse:
			[self error: 'slot rows do not contain a phrase tile morph']