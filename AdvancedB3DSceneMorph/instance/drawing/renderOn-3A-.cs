renderOn: aRenderer
	aRenderer getVertexBuffer flags: (aRenderer getVertexBuffer flags bitOr: VBTwoSidedLighting).
	super renderOn: aRenderer