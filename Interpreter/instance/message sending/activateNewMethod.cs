activateNewMethod
	| newContext methodHeader initialIP tempCount nilOop |
	methodHeader _ self headerOf: newMethod.
	newContext _ self allocateOrRecycleContext: (methodHeader bitAnd: LargeContextBit).

	initialIP _ ((LiteralStart + (self literalCountOfHeader: methodHeader)) * 4) + 1.
	tempCount _ (methodHeader >> 19) bitAnd: 16r3F.

	"Assume: newContext will be recorded as a root if necessary by the
	 call to newActiveContext: below, so we can use unchecked stores."

	self storePointerUnchecked: SenderIndex	ofObject: newContext
		withValue: activeContext.
	self storeWord: InstructionPointerIndex	ofObject: newContext
		withValue: (self integerObjectOf: initialIP).
	self storeWord: StackPointerIndex			ofObject: newContext
		withValue: (self integerObjectOf: tempCount).
	self storePointerUnchecked: MethodIndex ofObject: newContext
		withValue: newMethod.

	"Copy the reciever and arguments..."
	0 to: argumentCount do:
		[:i | self storePointerUnchecked: ReceiverIndex+i ofObject: newContext
			withValue: (self stackValue: argumentCount-i)].

	"clear remaining temps to nil in case it has been recycled"
	nilOop _ nilObj.
	argumentCount+1 to: tempCount do:
		[:i | self storePointerUnchecked: ReceiverIndex+i ofObject: newContext
			withValue: nilOop].

	self pop: argumentCount + 1.
	reclaimableContextCount _ reclaimableContextCount + 1.
	self newActiveContext: newContext.