primitiveRenderImage
	"Start/Proceed rendering the entire image"
	self export: true.
	self inline: false.

	self loadRenderingState ifFalse:[^interpreterProxy primitiveFail].

	self proceedRenderingScanline. "Finish this scan line"
	engineStopped ifTrue:[^self storeRenderingState].
	self proceedRenderingImage. "And go on as usual"

	self storeRenderingState.