processVertexBuffer: vb modelView: modelViewMatrix projection: projectionMatrix
	^self privateTransformVB: vb vertexArray 
			count: vb vertexCount
			modelViewMatrix: modelViewMatrix
			projectionMatrix: projectionMatrix
			flags: vb flags