pushMatrix
	"Push the current matrix"
	| theMatrix |
	theMatrix := B3DMatrix4x4 new.
	theMatrix loadFrom: currentMatrix.
	matrixStack addLast: theMatrix.