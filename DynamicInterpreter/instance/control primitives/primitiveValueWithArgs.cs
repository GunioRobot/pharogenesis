primitiveValueWithArgs

	| argumentArray blockContext blockArgumentCount arrayArgumentCount newContext newFrame oldSP |
	self assertStackPointerIsExternal.

	argumentArray _ self popStack.
	blockContext _ self popStack.
	self assertIsStableBlockContext: blockContext.
	blockArgumentCount _ self argumentCountOfBlock: blockContext.
	self successIfClassOf: argumentArray is: (self splObj: ClassArray).

	successFlag ifTrue: [
		arrayArgumentCount _ self fetchWordLengthOf: argumentArray.
		"Note:	refusing to activate a block context that is already activated used
				to be necessary when block contexts were reused during their
				activations.  This restriction could easily be relaxed now that
				they are copied for evaluation."
		self success: (arrayArgumentCount = blockArgumentCount
			and: [(self fetchPointer: CallerIndex ofObject: blockContext) = nilObj])].

	successFlag ifTrue: [
		oldSP _ self stackPointer.
		newFrame _ oldSP + 4.					"first free location"
		self pushRemappableOop: argumentArray.
		self pushRemappableOop: blockContext.
		newContext _ self allocateCachedContextAfter: activeCachedContext frame: newFrame.
		blockContext _ self popRemappableOop.
		argumentArray _ self popRemappableOop.

		stackOverflow ifTrue: [
			newFrame _ self cachedFramePointerAt: newContext.
			stackOverflow _ false.
		].

		self inlineTransfer:	arrayArgumentCount
			wordsFrom:		argumentArray + BaseHeaderSize
			to:				newFrame.

		self initializeCachedBlockContext: newContext fromClosure: blockContext.
		self cachedStackPointerAt: newContext put: (newFrame + (blockArgumentCount * 4) - 4).
		self cachedBlockArgumentCountAt: newContext put: (self integerObjectOf: blockArgumentCount).
"		self fetchContextRegisters: newContext."
	] ifFalse: [
		self push: blockContext.
		self push: argumentArray.
	].