computeIntersectionsOf: anArrayOfLineSegments
	segments _ anArrayOfLineSegments.
	self initializeEvents.
	self processEvents.
	^intersections contents