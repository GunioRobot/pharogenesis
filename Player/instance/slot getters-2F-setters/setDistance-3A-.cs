setDistance: aDistance
	"Set the object's distance from the origin to be as indicated, preserving its angle."

	| cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	cost cartesianXY: (Point r: aDistance degrees:  self getTheta)