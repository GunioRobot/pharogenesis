renderOn: aRenderer
	^aRenderer
		drawIndexedQuads: faces
			vertices: vertices
			normals: vtxNormals
			colors: vtxColors
			texCoords: vtxTexCoords.