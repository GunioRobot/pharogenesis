acceptDroppingMorph: aMorph event: evt

	super acceptDroppingMorph: aMorph event: evt.
	aMorph hasSubmorphs ifTrue:
		["Just dropped a sub-deck of cards"
		aMorph submorphs reverseDo: [:m | self addMorphFront: m]].
	(target ~~ nil and: [cardDroppedSelector ~~ nil]) ifTrue: [target perform: cardDroppedSelector]
