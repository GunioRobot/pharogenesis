getPenDown
	self player ifNil: [^ false].
	^ self actorState getPenDown