containsPoint: aPoint
	self startingIndex > text size ifTrue:
		["make null text frame visible"
		^ true].
	^ self paragraph containsPoint: aPoint