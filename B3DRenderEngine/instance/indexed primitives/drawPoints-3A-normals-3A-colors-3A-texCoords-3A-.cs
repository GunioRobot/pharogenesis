drawPoints: vertexArray normals: normalArray colors: colorArray texCoords: texCoordArray
	vertexBuffer reset.
	vertexBuffer primitive: 1.
	vertexBuffer 
		loadIndexed: #()
		vertices: vertexArray 
		normals: normalArray 
		colors: colorArray 
		texCoords: texCoordArray.
	^self renderPrimitive.