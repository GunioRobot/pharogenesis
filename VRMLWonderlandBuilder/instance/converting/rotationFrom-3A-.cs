rotationFrom: attr
	"Fix up coord systems"
	^B3DRotation radiansAngle: (attr at: 4) negated axis: 
			(B3DVector3 x: (attr at: 1) y: (attr at: 2) z: (attr at: 3))