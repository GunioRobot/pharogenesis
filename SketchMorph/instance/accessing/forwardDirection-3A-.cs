forwardDirection: degrees
	"Set the forward direction of the original Form. Angles are in degrees, increasing clockwise like a compass. Up is zero degrees."

	(0.0 - degrees) abs <= 0.0001
		ifTrue: [self removeProperty: #forwardDirection]
		ifFalse: [self setProperty: #forwardDirection toValue: degrees].
