renderPrimitive
	"Use underlying support for transform, clip and lighting if possible.
	This might actually be slower than the Squeak simulation but if the 
	hardware does in fact support TL then it's going to be REALLY fast."
	| projection |
	transformer needsUpdate ifTrue:[
		projection _ transformer projectionMatrix.
		self primRender: handle 
			setModelView: transformer modelViewMatrix 
			projection: projection.
		transformer needsUpdate: false.
	].
	shader needsLightUpdate ifTrue:[
		self primRender: handle setLights: shader primitiveLights.
		shader needsLightUpdate: false.
	].
	shader needsMaterialUpdate ifTrue:[
		self primRender: handle setMaterial: shader primitiveMaterial.
		shader needsMaterialUpdate: false.
	].
	^self processVertexBuffer: vertexBuffer.