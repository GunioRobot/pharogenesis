forwardDirection
	"Return my forward direction.  If #normal I am not flexed."

	^ rotationStyle == #normal 
		ifTrue: [0.0]
		ifFalse: [rotationDegrees]	"fwd dir kept here when leftRight, upDown, none"
