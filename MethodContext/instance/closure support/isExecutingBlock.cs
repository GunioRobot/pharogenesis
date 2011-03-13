isExecutingBlock
	"Is this executing a block versus a method"

	^ self method notNil and: [self method isBlockMethod]