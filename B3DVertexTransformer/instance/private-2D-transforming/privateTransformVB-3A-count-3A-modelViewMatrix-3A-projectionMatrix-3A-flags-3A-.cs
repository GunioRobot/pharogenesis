privateTransformVB: vertexArray count: vertexCount modelViewMatrix: modelViewMatrix projectionMatrix: projectionMatrix flags: flags
	| noW |
	(modelViewMatrix a41 = 0.0 and:[
		modelViewMatrix a42 = 0.0 and:[
			modelViewMatrix a43 = 0.0 and:[
				modelViewMatrix a44 = 1.0]]]) ifTrue:[noW _ true].
	noW ifTrue:[
		vertexArray upTo: vertexCount do:[:primitiveVertex|
			self privateTransformPrimitiveVertex: primitiveVertex
				byModelViewWithoutW: modelViewMatrix.
			self privateTransformPrimitiveVertex: primitiveVertex
				byProjection: projectionMatrix.
			(flags anyMask: VBVtxHasNormals)
				ifTrue:[self privateTransformPrimitiveNormal: primitiveVertex
							byMatrix: modelViewMatrix
							rescale: true].
		].
	] ifFalse:[
		vertexArray upTo: vertexCount do:[:primitiveVertex|
			self privateTransformPrimitiveVertex: primitiveVertex
				byModelView: modelViewMatrix.
			self privateTransformPrimitiveVertex: primitiveVertex
				byProjection: projectionMatrix.
			(flags anyMask: VBVtxHasNormals)
				ifTrue:[self privateTransformPrimitiveNormal: primitiveVertex
							byMatrix: modelViewMatrix
							rescale: true].
		].
	].