primitiveRenderScanline
	"Start rendering the entire image"
	self export: true.
	self inline: false.

	self loadRenderingState ifFalse:[^interpreterProxy primitiveFail].

	self proceedRenderingScanline. "Finish the current scan line"

	self storeRenderingState.