setRight: w
	"Set the right coordinate to the given value"

	| topLeftNow cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	topLeftNow _ cost cartesianBoundsTopLeft.
	^ cost right: cost left - topLeftNow x + w
