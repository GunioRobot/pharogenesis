pushActiveContextBytecode
	"Puts reclaimability of this context in question."

	self fetchNextBytecode.
	reclaimableContextCount _ 0.
	self internalPush: activeContext.
