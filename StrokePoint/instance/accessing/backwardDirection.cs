backwardDirection
	"Compute the backward direction to the previous point in the stroke."
	| dir |
	dir _ prev ifNil:[0@0] ifNotNil:[self position - prev position].
	dir isZero ifFalse:[dir _ dir normalized].
	^dir