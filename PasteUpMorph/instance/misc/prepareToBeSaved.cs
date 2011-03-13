prepareToBeSaved

	super prepareToBeSaved.
	self world ifNotNil:
		[self setProperty: #worldSize toValue: self world extent].
	turtlePen _ nil.
	lastTurtlePositions _ IdentityDictionary new.
