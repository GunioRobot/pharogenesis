add: aPoint
	lastPoint ifNotNil:[
		(aPoint = lastPoint position and:[removeDuplicates]) ifTrue:[^false].
	].
	self addPoint: aPoint.
	^true