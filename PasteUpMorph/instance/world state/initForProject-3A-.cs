initForProject: aWorldState

	worldState _ aWorldState.
	bounds _ Display boundingBox.
	color _ (Color r:0.937 g: 0.937 b: 0.937).
	self addHand: HandMorph new.
	self setProperty: #automaticPhraseExpansion toValue: true.
	self setProperty: #optimumExtentFromAuthor toValue: Display extent.
	self wantsMouseOverHalos: Preferences mouseOverHalos.
	self borderWidth: 0.
	model _ nil.
