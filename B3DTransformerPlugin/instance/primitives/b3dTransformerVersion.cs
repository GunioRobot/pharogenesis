b3dTransformerVersion
	"Return the current version of the transformer"
	self export: true.
	self inline: false.
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: 1.	"Version 1"