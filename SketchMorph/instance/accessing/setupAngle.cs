setupAngle
	"Return the forward direction of the original Form. Angles are in degrees, increasing clockwise like a compass. Up is zero degrees."

	^ (self valueOfProperty: #setupAngle) ifNil: [0.0]
