validateVertexOrder
	(v0 sortsBefore: v1) ifFalse:[self error:'Vertex order problem'].
	(v0 sortsBefore: v2) ifFalse:[self error:'Vertex order problem'].
	(v1 sortsBefore: v2) ifFalse:[self error:'Vertex order problem'].