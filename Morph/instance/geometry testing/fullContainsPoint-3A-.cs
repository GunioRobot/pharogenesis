fullContainsPoint: aPoint

	(self fullBounds containsPoint: aPoint) ifFalse: [^ false].  "quick elimination"
	self allMorphsDo:
		[:m | (m containsPoint: aPoint) ifTrue: [^ true]].
	^ false