primitiveSnapshot

	| activeProc dataSize rcvr activeCntx sp |
	self assertStackPointerIsExternal.
	"save the state of the current process and save it on the scheduler queue"
	activeCntx _ self flushCacheFrom: activeCachedContext.
	self assertIsNull: activeCachedContext.
	activeProc _ self fetchPointer: ActiveProcessIndex ofObject: self schedulerPointer.
	self storePointer: SuspendedContextIndex ofObject: activeProc withValue: activeCntx.

	"compact memory and compute the size of the memory actually in use"
	self pushRemappableOop: activeCntx.
	self incrementalGC.  "maximimize space for forwarding table"
	self fullGC.
	activeCntx _ self popRemappableOop.

	dataSize _ freeBlock - (self startOfMemory).
	"Assume: all objects are below the start of the free block"

	self assertIsStableContext: activeCntx.
	sp _ self fetchInteger: StackPointerIndex ofObject: activeCntx.

	successFlag ifTrue: [
		"Pop the receiver, push true"
		rcvr _ self fetchPointer:	TempFrameStart + sp - 1	ofObject: activeCntx.
		self storePointerUnchecked:	TempFrameStart + sp - 1	ofObject: activeCntx withValue: trueObj.
		self writeImageFile: dataSize.
		"Pop true off the stack"
		self storeInteger: StackPointerIndex ofObject: activeCntx withValue: sp - 1.
	].

	self copyContextToCache: activeCntx.
	self fetchContextRegisters: activeCachedContext.

	successFlag
		ifTrue: [ self push: falseObj ]
		ifFalse: [ self push: rcvr ].