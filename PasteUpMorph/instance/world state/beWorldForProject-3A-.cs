beWorldForProject: aProject

	self privateOwner: nil.
	worldState _ WorldState new initForWorld.
	self addHand: HandMorph new.
	self setProperty: #automaticPhraseExpansion toValue: true.
	self startSteppingSubmorphsOf: self