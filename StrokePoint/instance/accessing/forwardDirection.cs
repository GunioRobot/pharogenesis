forwardDirection
	"Compute the forward direction to the next point in the stroke."
	| dir |
	dir _ next ifNil:[0@0] ifNotNil:[next position - self position].
	dir isZero ifFalse:[dir _ dir normalized].
	^dir