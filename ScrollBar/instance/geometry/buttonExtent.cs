buttonExtent
	^ bounds isWide
		ifTrue: [11 @ self innerBounds height]
		ifFalse: [self innerBounds width @ 11]