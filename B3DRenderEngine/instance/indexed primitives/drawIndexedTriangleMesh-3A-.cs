drawIndexedTriangleMesh: aMesh
	^self drawIndexedTriangles: aMesh faces
			vertices: aMesh vertices
			normals: aMesh vertexNormals
			colors: aMesh vertexColors
			texCoords: aMesh texCoords.
