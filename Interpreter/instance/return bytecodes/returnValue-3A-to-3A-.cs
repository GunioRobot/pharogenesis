returnValue: resultObj to: returnContext
	"Note: Assumed to be inlined into the dispatch loop."

	| nilOop thisCntx contextOfCaller ctx |
	self inline: true.
	self sharedCodeNamed: 'commonReturn' inCase: 120.

	nilOop _ nilObj. "keep in a register"
	thisCntx _ activeContext.
	ctx _ thisCntx.
	"First scan to ensure non-nil senders. This feature, suggested by Craig Latta, catches attempts to return out of the scope of an ensure-block, before actually unwinding the stack."
	[ctx ~= returnContext and: [ctx ~= nilOop]]
		whileTrue: [ctx _ self fetchPointer: SenderIndex ofObject: ctx].

	"make sure we can return to the given context"
	((ctx = nilOop) or:[ (returnContext = nilOop) or:
	 [(self fetchPointer: InstructionPointerIndex ofObject: returnContext) = nilOop]])
		ifTrue:
		["error: sender's instruction pointer or context is nil; cannot return"
		self internalPush: activeContext.
		self internalPush: resultObj.
		messageSelector _ self splObj: SelectorCannotReturn.
		argumentCount _ 1.
		^ self normalSend].

	[thisCntx = returnContext]
		whileFalse:
		["climb up stack to returnContext"
		contextOfCaller _ self fetchPointer: SenderIndex ofObject: thisCntx.

		"zap exited contexts so any future attempted use will be caught"
		self storePointerUnchecked: SenderIndex ofObject: thisCntx withValue: nilOop.
		self storePointerUnchecked: InstructionPointerIndex ofObject: thisCntx withValue: nilOop.
		reclaimableContextCount > 0 ifTrue:
			["try to recycle this context"
			reclaimableContextCount _ reclaimableContextCount - 1.
			self recycleContextIfPossible: thisCntx].
		thisCntx _ contextOfCaller].

	activeContext _ thisCntx.
	(thisCntx < youngStart) ifTrue: [ self beRootIfOld: thisCntx ].

	self internalFetchContextRegisters: thisCntx.  "updates local IP and SP"
	self fetchNextBytecode.
	self internalPush: resultObj.
