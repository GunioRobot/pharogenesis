initialize

	super initialize.
	self setInitialState.
	pages _ OrderedCollection new.
	self addDressing.
	BookMorph turnOffSoundWhile: [self insertPage].
