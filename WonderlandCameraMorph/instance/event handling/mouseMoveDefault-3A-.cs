mouseMoveDefault: evt 

	| newEvent reactions |
	newEvent _ self convertEvent: evt.
	newEvent ifNil:[^self].

	newEvent getActor hasActiveTexture
		ifTrue: [^ newEvent getActor morphicMouseMove: newEvent].

	reactions _ newEvent getActor getReactionsTo: mouseMove.
	reactions ifNotNil: [reactions do: [:aReaction | aReaction reactTo: newEvent]].