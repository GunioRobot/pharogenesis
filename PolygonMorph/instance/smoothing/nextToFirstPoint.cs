nextToFirstPoint
	"For arrow direction"

	smoothCurve 
		ifTrue: 
			[curveState ifNil: [self coefficients].
			^curveState second]
		ifFalse: [^vertices second]