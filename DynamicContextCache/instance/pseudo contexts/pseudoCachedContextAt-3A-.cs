pseudoCachedContextAt: pc
	"Answer the cached context pointer for the PseudoContext pc.
	Notes:	The cached context pointer is encoded as an integer in the sender
			field of the PseudoContext.  Subtract 1 to get the real pointer."

	self inline: true.
	self assertIsPseudoContext: pc.
	self assertIsCachedContext: ((self fetchPointer: CachedContextIndex ofObject: pc) - 1).
	^(self fetchPointer: CachedContextIndex ofObject: pc) - 1