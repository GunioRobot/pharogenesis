zeroBasedFaces
	"Answer the faces using zero-based references. This is a hack for using OpenGL and B3D in parallel."
	zFaces ifNotNil:[^zFaces].
	zFaces := faces clone.
	1 to: zFaces basicSize do:[:i| zFaces basicAt: i put: (zFaces basicAt: i) - 1].
	^zFaces