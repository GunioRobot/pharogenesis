memoryMin
	"Setup the gc low/high water marks at the same time"
	gcLowWaterMark _ vmParameters at: 1.
	gcHighWaterMark _ vmParameters at: 1.
	^0