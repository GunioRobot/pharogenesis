checkIntersectionOf: frontFace with: backFace at: yValue edge: leftEdge
	"Compute the possible intersection of frontFace and backFace at the given y value.
	Store the earliest intersection in nextIntersection. Return false if the face enumeration
	should be aborted, true otherwise. leftEdge is the edge defining the left-most boundary
	for possible intersections (e.g., all intersections have to be >= leftEdge xValue)"
	| floatX floatY frontZ backZ xValue rightX |
	backFace minZ >= frontFace maxZ ifTrue:[^false]. "Abort. Everything behind will be further away."
	"Check for shared edge of faces"
	frontFace leftEdge == backFace leftEdge ifTrue:[^true]. "Proceed."
	frontFace rightEdge == backFace rightEdge ifTrue:[^true]. "Proceed."

	"Check for newly created front face"
	(frontFace leftEdge xValue bitShift: -12) = 
		(frontFace rightEdge xValue bitShift: -12) ifTrue:[^false]. "Abort"
	"Check for newly created back face"
	(backFace leftEdge xValue bitShift: -12) = 
		(backFace rightEdge xValue bitShift: -12) ifTrue:[^true]. "Proceed"

	"Compute the z value of either frontFace or backFace depending on whose
	right edge x value is less (so we test a point that is inside both faces)"
	floatY _ yValue.
	frontFace rightEdge xValue <= backFace rightEdge xValue ifTrue:[
		"Use frontFace rightEdge as reference value"
		frontZ _ frontFace rightEdge zValue.
		rightX _ frontFace rightEdge xValue.
		floatX _ rightX / 4096.0.
		backZ _ backFace zValueAtX: floatX y: floatY.
	] ifFalse:[
		"Use backFace rightEdge as reference value"
		backZ _ backFace rightEdge zValue.
		rightX _ backFace rightEdge xValue.
		floatX _ rightX / 4096.0.
		frontZ _ frontFace zValueAtX: floatX y: floatY.
	].
	backZ < frontZ ifTrue:[
		"Found a possible intersection."
		xValue _ self computeIntersectionOf: frontFace with: backFace at: yValue ifError: leftEdge xValue.
		"The following tests for numerical inaccuracies"
		xValue > rightX ifTrue:[xValue _ rightX].
		xValue < leftEdge xValue ifTrue:[
			"In theory, this cannot happen. We may, however, have slight
			numerical inaccuracies here, too. Conceptually, we treat these
			intersections as if they occured immediately at the same 
			fractional pixel in the scan line."
			xValue _ leftEdge xValue].
		(xValue bitShift: -12) = (leftEdge xValue bitShift: -12) ifTrue:[
			"Intersections at the same pixel are ignored. Process it at the next pixel.
			NOTE: This step is incredibly important! It is by ignoring intersections
			at the same pixel that we can never run in an endless repetition of
			intersections at the same pixel value."
			xValue _ (leftEdge xValue bitShift: -12) + 1 bitShift: 12.
		].
		xValue < nextIntersection xValue ifTrue:[
			nextIntersection xValue: xValue.
			nextIntersection leftFace: frontFace.
			nextIntersection rightFace: backFace.
		].
	].
	^true "proceed"