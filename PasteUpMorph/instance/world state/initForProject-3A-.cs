initForProject: aWorldState

	worldState := aWorldState.
	bounds := Display boundingBox.
	self color: Preferences defaultWorldColor.
	self addHand: HandMorph new.
	self setProperty: #optimumExtentFromAuthor toValue: Display extent.
	self wantsMouseOverHalos: Preferences mouseOverHalos.
	self borderWidth: 0.
	model := nil.
