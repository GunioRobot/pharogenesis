containsPoint: aPoint
	(self color alpha = 1.0 or: [Sensor blueButtonPressed])
		ifTrue: [^ super containsPoint: aPoint].
	^ false