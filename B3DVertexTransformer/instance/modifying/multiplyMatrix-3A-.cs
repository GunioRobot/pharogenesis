multiplyMatrix: aMatrix
	"Multiply aMatrix with the current matrix"
	currentMatrix *= aMatrix.
	needsUpdate _ true.