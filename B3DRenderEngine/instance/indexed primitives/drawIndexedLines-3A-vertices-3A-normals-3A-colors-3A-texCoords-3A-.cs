drawIndexedLines: indexArray vertices: vertexArray normals: normalArray colors: colorArray texCoords: texCoordArray
	vertexBuffer reset.
	vertexBuffer primitive: 4.
	vertexBuffer 
		loadIndexed: indexArray
		vertices: vertexArray 
		normals: normalArray 
		colors: colorArray 
		texCoords: texCoordArray.
	^self renderPrimitive.