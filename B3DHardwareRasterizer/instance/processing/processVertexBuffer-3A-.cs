processVertexBuffer: vb
	self primProcessVB: vb primitive 
			texture: (target textureHandleOf: texture) 
			vertices: vb vertexArray 
			vertexCount: vb vertexCount 
			faces: vb indexArray 
			faceCount: vb indexCount.
	^nil