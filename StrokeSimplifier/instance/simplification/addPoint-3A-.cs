addPoint: aPoint
	| strokePoint |
	strokePoint _ self asStrokePoint: aPoint.
	strokePoint prevPoint: lastPoint.
	lastPoint ifNotNil:[
		lastPoint do:[:pt| lastPoint _ pt].
		lastPoint nextPoint: strokePoint.
		lastPoint releaseCachedState].
	lastPoint _ strokePoint.
	points add: strokePoint.
	simplifyStroke ifTrue:[self simplifyIncrementally].
