processVertexBuffer: vb
	self primRenderVB: handle
		primitive: vb primitive 
		flags: vb flags
		texture: (self textureHandleOf: rasterizer texture)
		vertices: vb vertexArray 
		vertexCount: vb vertexCount 
		faces: vb indexArray 
		faceCount: vb indexCount.