projectParameters
	^ projectParameters ifNil: [self initializeProjectParameters]