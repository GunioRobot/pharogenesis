rememberCostume: aCostume
	"Put aCostume in my remembered-costumes list, as the final element"
	| costumeToRemember existing |
	costumeToRemember _ aCostume renderedMorph.
		"Remember real morphs, not their transformations"
	costumes ifNil: [costumes _ OrderedCollection new].
	existing _ (costumeToRemember isSketchMorph)
		ifTrue:
			[self knownSketchCostumeWithSameFormAs: costumeToRemember]
		ifFalse:
			[costumes detect: [:c | c == costumeToRemember] ifNone: [nil]].
	costumes _ costumes copyWithout: existing.
	costumes addLast: costumeToRemember