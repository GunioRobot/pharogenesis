getPenColor
	^ self player ifNotNil: [self actorState getPenColor] ifNil: [Color green]