initializeTarget
	"See if the renderer exposes its rendering target for blts.
	If so, initialize the rendere's target with a form that we can use."
	| targetHandle targetWidth targetHeight targetDepth rgbaBitMasks |
	targetHandle _ self primRenderGetSurfaceHandle: handle.
	targetHandle ifNil:[^target _ nil]. "nope"
	targetWidth _ self primRenderGetSurfaceWidth: handle.
	targetHeight _ self primRenderGetSurfaceHeight: handle.
	targetDepth _ self primRenderGetSurfaceDepth: handle.
	rgbaBitMasks _ Array new: 4.
	self primRender: handle getColorMasksInto: rgbaBitMasks.
	"Now we're all set up. Create the target form."
	target _ ExternalForm extent: targetWidth@targetHeight depth: targetDepth bits: nil.
	target setExternalHandle: targetHandle on: nil. "Since the form will be automatically destroyed"
	target colormapFromARGB: (ColorMap mappingFromARGB: rgbaBitMasks).
