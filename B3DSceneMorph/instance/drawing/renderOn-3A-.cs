renderOn: aRenderer
	aRenderer viewport: (self bounds insetBy: 1@1).
	aRenderer clearDepthBuffer.
	aRenderer loadIdentity.
	scene renderOn: aRenderer.