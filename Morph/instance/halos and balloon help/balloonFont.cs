balloonFont
	^ self
		valueOfProperty: #balloonFont
		ifAbsent: [self defaultBalloonFont]