rotateByMatrix: aMatrix
	"Rotate the object by composing its rotation matrix with the given matrix."

	composite _ composite composeWith: aMatrix.