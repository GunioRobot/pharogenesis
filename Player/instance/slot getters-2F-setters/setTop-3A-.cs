setTop: w
	"Set the top coordinate as indicated, using cartesian sense"

	| topLeftNow cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	topLeftNow _ cost cartesianBoundsTopLeft.
	^ cost top: cost top + topLeftNow y - w