setLeft: w
	"Set the object's left coordinate as indicated"

	| topLeftNow cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	topLeftNow _ cost cartesianBoundsTopLeft.
	^ cost left: cost left - topLeftNow x + w
