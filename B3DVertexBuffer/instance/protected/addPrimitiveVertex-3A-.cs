addPrimitiveVertex: pVtx
	"Add a primitive vertex to the list of vertices processed.
	Return the index of the vertex."
	vertexCount >= vertexArray size 
		ifTrue:[self growVertexArray: vertexCount * 3 // 2 + 100].
	vertexArray at: (vertexCount _ vertexCount + 1) put: pVtx.
	^vertexCount