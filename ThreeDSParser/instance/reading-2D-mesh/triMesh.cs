triMesh
	"Subchunk of namedObject"
	| objSpec |
	"Read vertex coordinates and indexed triangles"
	objSpec _ self recognize: #(
		(16r4110 vertexList ->)		"List of vertices"
		(16r4140 textureVertices ->)	"List of texture coords (per vertex)"
		(16r4160 matrix ->)			"Transformation of mesh object"
		(16r4120 triList ->)) 			"Triangle information (see #triList)"
			as: Dictionary.
	^self meshObjectClass from3DS: objSpec