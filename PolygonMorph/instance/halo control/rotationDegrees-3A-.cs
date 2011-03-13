rotationDegrees: degrees 
	| flex center |
	(center _ self valueOfProperty: #referencePosition) ifNil:
		[self setProperty: #referencePosition toValue: (center _ self bounds center)].
	flex _ (MorphicTransform offset: center negated)
			withAngle: (degrees - self forwardDirection) degreesToRadians.
	self setVertices: (vertices collect: [:v | (flex transform: v) - flex offset]).
	self forwardDirection: degrees.

