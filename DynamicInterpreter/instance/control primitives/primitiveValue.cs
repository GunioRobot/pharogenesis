primitiveValue

	| blockContext blockArgumentCount newContext newFrame oldSP oldContext numArgs |
	self assertStackPointerIsExternal.
	numArgs _ argumentCount.
	blockContext _ self stackValue: numArgs.
	self assertIsStableBlockContext: blockContext.
	blockArgumentCount _ self argumentCountOfBlock: blockContext.
	self success: (numArgs = blockArgumentCount
			and: [(self fetchPointer: CallerIndex ofObject: blockContext) = nilObj]).
	successFlag ifTrue: [
		oldContext		_ activeCachedContext.
		oldSP			_ self cachedStackPointerAt: oldContext.
		newFrame		_ oldSP - (numArgs * 4) + 4.	"first argument"
		self pushRemappableOop: blockContext.
		newContext		_ self allocateCachedContextAfter: oldContext frame: newFrame.  "GC!"
		blockContext _ self popRemappableOop.
		self cachedStackPointerAt: oldContext put: (newFrame - 8).	"updated AFTER possible GC"

		stackOverflow ifTrue: [
			newFrame _ self cachedFramePointerAt: newContext.
			self	transfer:	numArgs
				wordsFrom:	oldSP - (numArgs * 4) + 4		"first argument"
				to:			newFrame.
			stackOverflow _ false.
		].

		self initializeCachedBlockContext: newContext fromClosure: blockContext.
		self cachedStackPointerAt: newContext put: (newFrame + (numArgs * 4) - 4).
		self cachedBlockArgumentCountAt: newContext put: (self integerObjectOf: blockArgumentCount).
"		self fetchContextRegisters: newContext."
	]