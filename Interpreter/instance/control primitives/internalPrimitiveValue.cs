internalPrimitiveValue
	| newContext blockArgumentCount initialIP |
	self inline: true.
	self sharedCodeNamed: 'commonPrimitiveValue' inCase: 201.
	successFlag _ true.
	newContext _ self internalStackValue: argumentCount.
	self assertClassOf: newContext is: (self splObj: ClassBlockContext).
	blockArgumentCount _ self argumentCountOfBlock: newContext.

	self success: (argumentCount = blockArgumentCount and: [(self fetchPointer: CallerIndex ofObject: newContext) = nilObj]).

	successFlag
		ifTrue: ["This code assumes argCount can only = 0 or 1"
			argumentCount = 1
				ifTrue: [self storePointer: TempFrameStart ofObject: newContext withValue: self internalStackTop].
			self internalPop: argumentCount + 1.
			initialIP _ self fetchPointer: InitialIPIndex ofObject: newContext.
			self storePointerUnchecked: InstructionPointerIndex ofObject: newContext withValue: initialIP.
			self storeStackPointerValue: argumentCount inContext: newContext.
			self storePointerUnchecked: CallerIndex ofObject: newContext withValue: activeContext.
			self internalNewActiveContext: newContext]
		ifFalse: [messageSelector _ self specialSelector: 25 + argumentCount.
			self normalSend]