drawPolygonAfter: aBlock
	vertexBuffer reset.
	vertexBuffer primitive: 3.
	aBlock value.
	^self renderPrimitive.