addNextPoint
	lastStrokePoint ifNotNil:[
		lastStrokePoint releaseCachedState.
		lastStrokePoint nextPoint: lastPoint.
		lastPoint prevPoint: lastStrokePoint.
		self simplifyLineFrom: lastPoint.
	].
	lastStrokePoint _ lastPoint.
	distance _ 0. "Distance since last stroke point"
	samples _ 0.	 "Samples since last stroke point"
	time _ 0. "Time since last stroke point"