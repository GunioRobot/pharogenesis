b3dStartRasterizer
	"Primitive. Start the rasterizer."
	| errCode |
	self export: true.
	self inline: false.
	"Check argument count"
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].

	"Load the base rasterizer state"
	(self loadRasterizerState: 2)
		ifFalse:[^interpreterProxy primitiveFail].
	"Load the textures"
	self loadTexturesFrom: 0.
	interpreterProxy failed ifTrue:[^nil].
	"And the objects"
	self loadObjectsFrom: 1.
	interpreterProxy failed ifTrue:[^nil].
	"And go ..."
	errCode _ self cCode:'b3dMainLoop(&state, B3D_NO_ERROR)'.
	self storeObjectsInto: 1.
	interpreterProxy pop: 4.
	interpreterProxy pushInteger: errCode.