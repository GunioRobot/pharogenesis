addClipVertex: pVtx
	"Add a primitive vertex to the list of vertices processed.
	Return the index of the vertex."
	vertexCount >= vertexArray size 
		ifTrue:[self growVertexArray: vertexCount + (vertexCount // 4) + 10].
	vertexArray at: (vertexCount _ vertexCount + 1) put: pVtx.
	^vertexCount