position
	"Return the position of the light.
	This member is valid only if the light is not positional 
	(e.g., the direction must be computed for every vertex)"
	^B3DVector3
		x: self positionX
		y: self positionY
		z: self positionZ