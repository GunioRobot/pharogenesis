rotationFrom: attr
	"Fix up coord systems.
	FIXME: attr should always be a B3DRotation but for now
	the defaults are arrays. How ugly..."
	attr class == Array
		ifTrue:[^B3DRotation radiansAngle: (attr at: 4) negated axis: 
			(B3DVector3 x: (attr at: 1) y: (attr at: 2) z: (attr at: 3))]
		ifFalse:[^attr negated]