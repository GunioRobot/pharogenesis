balloonColor
	^ self
		valueOfProperty: #balloonColor
		ifAbsent: [self defaultBalloonColor]