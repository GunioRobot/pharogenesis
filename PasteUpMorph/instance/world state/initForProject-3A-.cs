initForProject: aWorldState

	worldState _ aWorldState.
	bounds _ Display boundingBox.
	self color: Preferences defaultWorldColor.
	self addHand: HandMorph new.
	self setProperty: #automaticPhraseExpansion toValue: true.
	self setProperty: #optimumExtentFromAuthor toValue: Display extent.
	self wantsMouseOverHalos: Preferences mouseOverHalos.
	self borderWidth: 0.
	model _ nil.
