estimatedLengthOf: deltaX with: deltaY
	"Estimate the length of the vector described by deltaX and deltaY.
	This method may be extremely inaccurate - use it only
	if you know exactly that this doesn't matter. Otherwise
	use #accurateLengthOf:width:"
	| absDx absDy |
	deltaX >= 0 ifTrue:[absDx _ deltaX] ifFalse:[absDx _ 0 - deltaX].
	deltaY >= 0 ifTrue:[absDy _ deltaY] ifFalse:[absDy _ 0 - deltaY].
	absDx > absDy 
		ifTrue:[^absDx + (absDy // 2)]
		ifFalse:[^absDy + (absDx // 2)]

