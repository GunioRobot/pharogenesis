vertexNormals
	^vtxNormals ifNil:[vtxNormals _ self computeVertexNormals].