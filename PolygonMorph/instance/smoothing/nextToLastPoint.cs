nextToLastPoint
	"For arrow direction"

	smoothCurve 
		ifTrue: 
			[curveState ifNil: [self coefficients].
			^curveState third]
		ifFalse: [^vertices at: vertices size - 1]