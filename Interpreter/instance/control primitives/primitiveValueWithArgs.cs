primitiveValueWithArgs

	| argumentArray blockContext blockArgumentCount arrayArgumentCount initialIP |
	argumentArray _ self popStack.
	blockContext _ self popStack.
	blockArgumentCount _ self argumentCountOfBlock: blockContext.
	self assertClassOf: argumentArray is: (self splObj: ClassArray).
	successFlag ifTrue: [
		arrayArgumentCount _ self fetchWordLengthOf: argumentArray.
		self success: (arrayArgumentCount = blockArgumentCount
			and: [(self fetchPointer: CallerIndex ofObject: blockContext) = nilObj])].
	successFlag ifTrue: [
		self transfer: arrayArgumentCount
			fromIndex: 0
			ofObject: argumentArray
			toIndex: TempFrameStart
			ofObject: blockContext.

		"Assume: The call to transfer:... makes blockContext a root if necessary,
		 allowing use to use unchecked stored in the following code."
		initialIP _ self fetchPointer: InitialIPIndex			ofObject: blockContext.
		self storePointerUnchecked: InstructionPointerIndex	ofObject: blockContext
			withValue: initialIP.
		self storeStackPointerValue: arrayArgumentCount	inContext: blockContext.
		self storePointerUnchecked: CallerIndex				ofObject: blockContext
			withValue: activeContext.
		self newActiveContext: blockContext.
	] ifFalse: [self unPop: 2].