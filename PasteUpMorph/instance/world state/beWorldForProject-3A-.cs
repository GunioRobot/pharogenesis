beWorldForProject: aProject

	self privateOwner: nil.
	worldState := WorldState new.
	self addHand: HandMorph new.
	self setProperty: #optimumExtentFromAuthor toValue: Display extent.
	self startSteppingSubmorphsOf: self