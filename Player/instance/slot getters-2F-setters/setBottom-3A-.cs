setBottom: w
	"Set the bottom coordinate (cartesian sense) of the object as requested"

	| topLeftNow cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	topLeftNow _ cost cartesianBoundsTopLeft.
	^ cost bottom: cost top + topLeftNow y - w
