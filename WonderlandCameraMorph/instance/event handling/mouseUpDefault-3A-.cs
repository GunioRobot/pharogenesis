mouseUpDefault: evt
	| newEvent reactions |
	newEvent _ self convertEvent: evt.
	newEvent ifNil: [^ self].

	newEvent getActor hasActiveTexture 
		ifTrue: [^ newEvent getActor morphicMouseUp: newEvent].

	reactions _ newEvent getActor getReactionsTo: mouseUpButton.
	reactions ifNotNil: [reactions do: [:aReaction | aReaction reactTo: newEvent]]