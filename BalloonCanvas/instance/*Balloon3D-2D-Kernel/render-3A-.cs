render: anObject
	| b3d |
	b3d _ (B3DRenderEngine defaultForPlatformOn: form).
	"Install the viewport offset"
	b3d viewportOffset: origin.
	"Install the clipping rectangle for the target form"
	b3d clipRect: clipRect.
	anObject renderOn: b3d.
	b3d flush.