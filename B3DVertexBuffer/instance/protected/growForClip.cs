growForClip
	vertexCount*2+100 > vertexArray size ifTrue:[self growVertexArray: vertexCount*2+100].
	indexCount*2+100 > indexArray size ifTrue:[self growIndexArray: indexCount*2+100].