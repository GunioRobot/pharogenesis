initialize
"initialize the state of the receiver"
	super initialize.
""
	self setInitialState.
	pages _ OrderedCollection new.
	self showPageControls.
	self class
		turnOffSoundWhile: [self insertPage]