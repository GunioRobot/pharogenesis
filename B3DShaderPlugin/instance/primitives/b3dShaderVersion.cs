b3dShaderVersion
	"Return the current shader version."
	self export: true.
	self inline: false.
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: 1.	"Version 1"