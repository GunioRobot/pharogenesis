initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self addMorph: (leftEye _ EyeMorph new);
	  addMorph: (rightEye _ EyeMorph new);
	  addMorph: (lips _ LipsMorph new).
	leftEye position: self position.
	rightEye position: leftEye extent x @ 0 + leftEye position.
	lips position: 0 @ 20 + (leftEye bottomRight + rightEye bottomLeft - lips extent // 2).
	self bounds: self fullBounds