switchRotationStatus
	self isRotating
		ifTrue: [self beStill]
		ifFalse: [self beRotating]