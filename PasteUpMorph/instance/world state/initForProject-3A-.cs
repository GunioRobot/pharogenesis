initForProject: aWorldState

	worldState _ aWorldState.
	color _ (Color r:0.937 g: 0.937 b: 0.937).
	self addHand: HandMorph new.
	self setProperty: #automaticPhraseExpansion toValue: true.
	model _ nil.
