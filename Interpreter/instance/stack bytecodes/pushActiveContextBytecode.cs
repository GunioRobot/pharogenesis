pushActiveContextBytecode
	"Puts reclaimability of this context in question."

	reclaimableContextCount _ 0.
	self internalPush: activeContext.