setScaleFactor: aNumber
	"Set the scale factor to be the given value"

	| cost |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	cost scaleFactor: ((aNumber asFloat max: 0.1) min: 10.0)