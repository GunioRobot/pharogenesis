getPenColor
	^ costumee ifNotNil: [self actorState getPenColor] ifNil: [Color green]