pickObjectAndVertexAt: aPoint
	"Return an association with the top object and the primitive vertex at the given point or nil"
	^self render: (B3DRenderEngine defaultForPlatformOn: nil) 
		pickingAt: aPoint
		withPrimitiveVertex: true.