render
	| b3d |
	b3d _ (B3DRenderEngine defaultForPlatformOn: Display).
	b3d viewport: (0@0 extent: 600@600).
	clearColor ifNotNil:[b3d clearViewport: clearColor].
	b3d clearDepthBuffer.
	"b3d addLight: (B3DAmbientLight color: Color white)."
	self renderOn: b3d.
	b3d finish.
	b3d destroy.