translateBy: aVector
	"Add the translation defined by aVector to the current matrix"
	self transformBy: (B3DMatrix4x4 identity setTranslation: aVector).