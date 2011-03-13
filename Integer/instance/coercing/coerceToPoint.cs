coerceToPoint
	"Coerce the receiver into a point by taking the high order part as the vertical coordinate and the low order part as the horizontal coordinate.  The part divisin is at 65536."

	| x y |
	x _ self bitAnd: 16rFFFF.
	y _ self bitShift: -16.
	(x >= 16r8000) ifTrue: [ x _ x - 16r10000 ].
	(y >= 16r8000) ifTrue: [ y _ y - 16r10000 ].
	^ Point x: x y: y
