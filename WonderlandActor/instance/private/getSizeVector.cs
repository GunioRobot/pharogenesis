getSizeVector
	"Returns the object's current size as a vector"

	^ (B3DVector3 x: (scaleMatrix a11) y: (scaleMatrix a22) z: (scaleMatrix a33)).
