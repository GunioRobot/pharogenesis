privateTransformVB: vb
	vpTransform 
		ifNil:[^transformer processVertexBuffer: vb]
		ifNotNil:["We must override the projection matrix here"
			^transformer
				processVertexBuffer: vb
					modelView: transformer modelViewMatrix
					projection: (transformer projectionMatrix composedWithGlobal: vpTransform)].