drawIndexedTriangles: indexArray vertices: vertexArray normals: normalArray colors: colorArray texCoords: texCoordArray
	vertexBuffer reset.
	vertexBuffer primitive: 5.
	vertexBuffer 
		loadIndexed: indexArray
		vertices: vertexArray 
		normals: normalArray 
		colors: colorArray 
		texCoords: texCoordArray.
	^self renderPrimitive.