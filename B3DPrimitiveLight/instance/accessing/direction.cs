direction
	"Return the direction of the light.
	This member is valid only if the light is not positional 
	(e.g., the direction must be computed for every vertex)"
	^B3DVector3
		x: self directionX
		y: self directionY
		z: self directionZ