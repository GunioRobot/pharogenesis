buttonExtent
	^ bounds isWide
		ifTrue: [9 @ self innerBounds height]
		ifFalse: [self innerBounds width @ 9]