computeVertexNormals
	"Compute the vertex normals for the receiver.
	Note: This is a multi pass process here - we may have to split up vertices"
	| set dict |
	set _ self detectNonSmoothVertices.
	set isEmpty ifFalse:[
		"Collect the dictionary of vertices to split"
		dict _ self collectSplitVertices: set.
		"And actually split them"
		self splitVerticesFrom: dict.
	].
	"Now do the actual computation"
	^super computeVertexNormals