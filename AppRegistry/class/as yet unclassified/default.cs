default
	^ default ifNil: [self askForDefault]