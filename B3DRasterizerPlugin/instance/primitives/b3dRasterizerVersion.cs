b3dRasterizerVersion
	"Primitive. Return the version of the rasterizer."
	self export: true.
	self inline: false.
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: 1. "Version 1"