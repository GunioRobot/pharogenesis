tilePhrasesForCategory: aCategory inViewer: aViewer
	"Return an array of phrases for the category"

	^ (self tilePhrasesSpecsForCategory: aCategory) collect:
		[:aSpec |
			aSpec first == #slot
				ifTrue:
					[aViewer phraseForSlot: aSpec]
				ifFalse:
					[self commandPhraseFor: aSpec inViewer: aViewer]]