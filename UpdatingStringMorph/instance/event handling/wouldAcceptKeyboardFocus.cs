wouldAcceptKeyboardFocus
	^ (self hasProperty: #okToTextEdit) or: [super wouldAcceptKeyboardFocus]