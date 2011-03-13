initialize

	| earMorph |
	super initialize.
	color _ Color yellow.
	earMorph _ (EToyListenerMorph makeListeningToggle: true) asMorph.
	earMorph setBalloonText: 'My presence in this world means received morphs may appear automatically'.
	self addARow: {earMorph}.

