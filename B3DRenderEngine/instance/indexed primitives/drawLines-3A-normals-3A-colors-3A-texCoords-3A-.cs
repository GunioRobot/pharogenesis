drawLines: vertexArray normals: normalArray colors: colorArray texCoords: texCoordArray
	vertexBuffer reset.
	vertexBuffer primitive: 2.
	vertexBuffer 
		loadIndexed: #()
		vertices: vertexArray 
		normals: normalArray 
		colors: colorArray 
		texCoords: texCoordArray.
	^self renderPrimitive.