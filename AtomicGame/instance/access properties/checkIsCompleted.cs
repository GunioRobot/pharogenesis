checkIsCompleted
	"Checks if the level is completed"
	| map result |
	result _ ((self submorphs
				select: [:each | each isKindOf: AtomicAtom])
				select: [:each | each isPreview not])
				allSatisfy: [:each | each fullyLinked].
	result
		ifTrue: ["how many movements"
			gameMoves _ gameMoves + mapMoves.
			"Has next map?"
			map _ self createNextMap.
			map
				ifNil: ["No selection"
					self select: nil.
					"show a final message"
					infoMorph contents: 'YOU WON !!!!!!' translated]
				ifNotNil: ["Go to the next level"
					self goLevel: map]]