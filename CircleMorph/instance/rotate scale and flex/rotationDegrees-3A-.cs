rotationDegrees: degrees
	| ref newPos flex origAngle origCenter |
	ref _ self referencePosition.
	origAngle _ self valueOfProperty: #originalAngle ifAbsentPut: [ self heading ].
	origCenter _ self valueOfProperty: #originalCenter ifAbsentPut: [ self center ].
	flex _ (MorphicTransform offset: ref negated)
			withAngle: (degrees - origAngle) degreesToRadians.
	newPos _ (flex transform: origCenter) - flex offset.
	self position: (self position + newPos - self center) asIntegerPoint.
	self setProperty: #referencePosition toValue: ref.
	self setProperty: #originalAngle toValue: origAngle.
	self setProperty: #originalCenter toValue: origCenter.
	self forwardDirection: degrees.
	self changed.
