nextToFirstPoint  "For arrow direction"
	smoothCurve
		ifTrue: [curveState ifNil: [self coefficients].
				^ curveState at: 2]
		ifFalse: [^ vertices at: 2]