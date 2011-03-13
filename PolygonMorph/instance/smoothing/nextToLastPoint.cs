nextToLastPoint  "For arrow direction"
	smoothCurve
		ifTrue: [curveState ifNil: [self coefficients].
				^ curveState at: 3]
		ifFalse: [^ vertices at: vertices size - 1]