scaleByMatrix: aMatrix
	"Scale the object by composing its scale matrix with the given matrix."

	scaleMatrix _ scaleMatrix composeWith: aMatrix.