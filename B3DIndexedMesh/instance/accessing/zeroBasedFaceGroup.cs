zeroBasedFaceGroup
	"Answer the faces using zero-based references. This is a hack for using OpenGL and B3D in parallel."
	| myFaces |
	myFaces := IntegerArray new: faces basicSize.
	1 to: faces basicSize do:[:i| myFaces at: i put: (faces basicAt: i) - 1].
	^myFaces