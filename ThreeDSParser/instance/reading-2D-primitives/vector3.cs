vector3
	"Generic Subchunk containing a vector"
	| x y z |
	x _ self float.
	"Swap z and y"
	z _ self float.
	y _ self float.
	^B3DVector3 x: x y: y z: z