containsPoint: aPoint
	(bounds containsPoint: aPoint) ifFalse: [^ false].
	^ self firstSubmorph containsPoint: (transform transform: aPoint)