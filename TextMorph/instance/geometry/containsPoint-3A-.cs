containsPoint: aPoint
	(super containsPoint: aPoint) ifFalse: [^false].
	self startingIndex > text size ifTrue:
		["make null text frame visible"
		^ super containsPoint: aPoint].
	^ self paragraph containsPoint: aPoint
