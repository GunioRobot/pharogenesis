setRotationMatrix: aMatrix
	"Rotate the object by blamming the rotation component of its matrix with the given matrix."

	composite a11: (aMatrix a11).
	composite a12: (aMatrix a12).
	composite a13: (aMatrix a13).

	composite a21: (aMatrix a21).
	composite a22: (aMatrix a22).
	composite a23: (aMatrix a23).

	composite a31: (aMatrix a31).
	composite a32: (aMatrix a32).
	composite a33: (aMatrix a33).
