initialize

	super initialize.
	self setInitialState.
	pages _ OrderedCollection new.
	self showPageControls.
	self class turnOffSoundWhile: [self insertPage].
