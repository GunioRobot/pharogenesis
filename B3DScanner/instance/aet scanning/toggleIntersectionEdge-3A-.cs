toggleIntersectionEdge: edge
	"Toggle the faces of the given intersection edge.
	This is a *very* special case."
	fillList first == edge leftFace ifFalse:[^self error:'Left face of intersection edge not top face'].
	fillList remove: edge rightFace.
	fillList addFront: edge rightFace. 