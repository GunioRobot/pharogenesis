processVertexBuffer: vb
	| box |
	box _ self primProcessVB: vb primitive 
			texture: (target textureHandleOf: texture) 
			vertices: vb vertexArray 
			vertexCount: vb vertexCount 
			faces: vb indexArray 
			faceCount: vb indexCount.
	^box ifNotNil:[(box at: 1) @ (box at: 2) corner: (box at: 3) @ (box at: 4)]