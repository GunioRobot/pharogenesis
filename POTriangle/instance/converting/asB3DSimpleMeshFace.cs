asB3DSimpleMeshFace
	| vectors |
	vectors _ self vertices collect: [:vertex | B3DSimpleMeshVertex new position: vertex asB3DVector3].
	^ B3DSimpleMeshFace withAll: vectors