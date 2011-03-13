fromBMPFileNamed: fileName depth: desiredDepth
	"Read the BMP file of the given name, reducing its depth if so desired."
	"Form fromBMPFileNamed: 'FulS.bmp' depth: 16"

	| fullDepth reducedDepth |
	fullDepth _ self fromBMPFileNamed: fileName.
	desiredDepth = 24 ifTrue: [^ fullDepth].
	reducedDepth _ Form extent: fullDepth extent depth: desiredDepth.
	fullDepth displayOn: reducedDepth.
	^ reducedDepth
