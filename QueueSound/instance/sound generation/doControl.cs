doControl
	super doControl.
	self currentSound notNil ifTrue: [self currentSound doControl]