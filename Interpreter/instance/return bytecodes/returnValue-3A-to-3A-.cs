returnValue: resultObj to: returnContext
	"Note: Assumed to be inlined into the dispatch loop."

	| nilOop thisCntx methodContextClass contextOfCaller |
	self inline: true.
	self sharedCodeNamed: 'commonReturn' inCase: 120.

	nilOop _ nilObj. "keep in a register"
	thisCntx _ activeContext.
	methodContextClass _ self splObj: ClassMethodContext.

	"make sure we can return to the given context"
	((returnContext = nilOop) or:
	 [(self fetchPointer: InstructionPointerIndex ofObject: returnContext) = nilOop]) ifTrue: [
		"error: sender's instruction pointer or context is nil; cannot return"
		self internalPush: activeContext.
		self internalPush: resultObj.
		messageSelector _ self splObj: SelectorCannotReturn.
		argumentCount _ 1.
		^ self normalSend
	].

	[thisCntx = returnContext] whileFalse: [
		"climb up stack to returnContext"
		contextOfCaller _ self fetchPointer: SenderIndex ofObject: thisCntx.

		"zap exited contexts so any future attempted use will be caught"
		self storePointerUnchecked: SenderIndex ofObject: thisCntx withValue: nilOop.
		self storePointerUnchecked: InstructionPointerIndex ofObject: thisCntx withValue: nilOop.

		reclaimableContextCount > 0 ifTrue: [
			"try to recycle this context"
			reclaimableContextCount _ reclaimableContextCount - 1.
			self recycleContextIfPossible: thisCntx methodContextClass: methodContextClass.
		].
		thisCntx _ contextOfCaller.
	].
	activeContext _ thisCntx.
	(thisCntx < youngStart) ifTrue: [ self beRootIfOld: thisCntx ].

	self internalFetchContextRegisters: thisCntx.  "updates local IP and SP"
	self internalPush: resultObj.
	self internalQuickCheckForInterrupts.
