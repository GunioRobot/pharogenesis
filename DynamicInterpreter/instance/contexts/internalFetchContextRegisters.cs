internalFetchContextRegisters
	"Need only to fetch the local registers from the cached context."

	self inline: true.
	self setTemporaryPointer: (self temporaryPointerForCachedContext: activeCachedContext).
	self internalizeIPandSP.
	self addRootsForCachedContext: localCP.