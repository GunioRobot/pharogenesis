renderOn: aRenderer
	self hasVertexColors ifTrue:[
		aRenderer trackAmbientColor: true.
		aRenderer trackDiffuseColor: true].
	^aRenderer
		drawIndexedTriangles: faces
			vertices: vertices
			normals: vtxNormals
			colors: vtxColors
			texCoords: vtxTexCoords.