angleTo: anHalfedge 
	"Returns the angle in radians between self and anHalfedge as if they
	had the same origin. The angle is measured counter clockwise."
	| angle |
	angle _ ((self vector dotProduct: anHalfedge vector)
				/ (self length * anHalfedge length)) safeArcCos.
	(self sideOf: anHalfedge destination)
		= #right ifTrue: [angle _ 2 * Float pi - angle].
	^ angle