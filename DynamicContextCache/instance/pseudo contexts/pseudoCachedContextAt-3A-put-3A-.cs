pseudoCachedContextAt: pc put: cachePointer
	"Store the cached context pointer for the PseudoContext pc.
	Notes:	The cached context pointer is encoded as an integer in the sender
			field of the PseudoContext.  Add 1 to get the encoded integer."

	self inline: true.
	self assertIsPseudoContext: pc.
	self assertIsCachedContext: cachePointer.
	self storeWord: CachedContextIndex ofObject: pc withValue: cachePointer + 1