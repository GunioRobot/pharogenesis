pickAt: aPoint
	"Return the top object at the given point or nil"
	^self render: (B3DRenderEngine defaultForPlatformOn: nil) pickingAt: aPoint