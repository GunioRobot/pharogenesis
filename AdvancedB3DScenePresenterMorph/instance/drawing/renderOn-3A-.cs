renderOn: aRenderer

    scene isNil ifTrue: [^self].
	aRenderer getVertexBuffer flags: (aRenderer getVertexBuffer flags bitOr: VBTwoSidedLighting).
	super renderOn: aRenderer