tilePhrasesForCategory: aCategory inViewer: aViewer
	"Return an array of phrases, each in one of the following two formats:
		(slot		heading		number				readWrite	getHeading		setHeading:)
		(script		command 	wearCostumeOf: 	player)"

	^ (self tilePhrasesSpecsForCategory: aCategory) collect:
		[:aSpec |
			aSpec first == #slot
				ifTrue:
					[self slotPhraseFor: aSpec inViewer: aViewer]
				ifFalse:
					[self commandPhraseFor: aSpec inViewer: aViewer]]