renderOn: aRenderer
	camera ifNotNil:[
		aRenderer viewport: (self bounds insetBy: 1@1).
		aRenderer clearDepthBuffer.
		aRenderer loadIdentity.
		camera renderOn: aRenderer].
	aRenderer texture: texture.
	aRenderer transformBy: (B3DRotation angle: angle axis: 0@1@0).
	geometry ifNotNil:[geometry renderOn: aRenderer].