faces
	"Construct and return triangles"
	| firstEdge nextEdge lastEdge |
	firstEdge _ nextEdge _ startingEdge first.
	[lastEdge _ nextEdge.
	nextEdge _ nextEdge originNext.
	nextEdge == firstEdge] whileFalse:[
		"Make up a triangle between lastEdge and nextEdge"
	].
