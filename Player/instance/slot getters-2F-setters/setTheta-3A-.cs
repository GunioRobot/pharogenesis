setTheta: aTheta
	"Set the object's position such that its rho is unchanged but the angle between the positive x-axis and the vector connecting the origin and the object's position is as given."

	| cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	cost cartesianXY: (Point r: self getDistance degrees: aTheta)