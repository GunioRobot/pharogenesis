fromBMPFileNamed: fileName depth: newDepth
	"Reduce the depth from 24 bits if the user wants to.
	Form fromBMPFileNamed: 'FulS.bmp' depth: 16"

	| pic24Bit picNewBit |
	pic24Bit _ self fromBMPFileNamed: fileName.
	picNewBit _ Form extent: pic24Bit extent depth: newDepth.
	pic24Bit displayOn: picNewBit.
	"pic24Bit will get recycled as soon as we return from this method"
	^ picNewBit
