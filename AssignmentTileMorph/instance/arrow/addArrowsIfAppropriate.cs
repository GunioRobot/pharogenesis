addArrowsIfAppropriate
	"If the receiver's slot is of an appropriate type, add arrows to the tile."

	(Vocabulary vocabularyForType: dataType)
		ifNotNilDo:
			[:aVocab | aVocab wantsAssignmentTileVariants ifTrue:
				[self addArrows]].
	(assignmentSuffix = ':') ifTrue:
		[ self addMorphBack: (ImageMorph new image: (ScriptingSystem formAtKey: #NewGets)).
		(self findA: StringMorph) ifNotNilDo: [ :sm |
			(sm contents endsWith: ' :') ifTrue: [ sm contents: (sm contents allButLast: 2) ]]]