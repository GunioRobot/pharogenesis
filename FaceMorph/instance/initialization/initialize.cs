initialize
	super initialize.
	color _ Color transparent.
	self addMorph: (leftEye _ EyeMorph new).
	self addMorph: (rightEye _ EyeMorph new).
	self addMorph: (lips _ LipsMorph new).
	leftEye position: self position.
	rightEye position: leftEye extent x @ 0 + leftEye position.
	lips position: (0 @ 20 + (leftEye bottomRight + rightEye bottomLeft - lips extent // 2)).
	self bounds: self fullBounds