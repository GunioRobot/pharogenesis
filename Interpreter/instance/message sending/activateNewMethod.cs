activateNewMethod
	| newContext methodHeader initialIP tempCount nilOop where |

	methodHeader _ self headerOf: newMethod.
	newContext _ self allocateOrRecycleContext: (methodHeader bitAnd: LargeContextBit).

	initialIP _ ((LiteralStart + (self literalCountOfHeader: methodHeader)) * 4) + 1.
	tempCount _ (methodHeader >> 19) bitAnd: 16r3F.

	"Assume: newContext will be recorded as a root if necessary by the
	 call to newActiveContext: below, so we can use unchecked stores."

	where _  newContext  + BaseHeaderSize.
	self longAt: where + (SenderIndex << 2) put: activeContext.
	self longAt: where + (InstructionPointerIndex << 2) put: (self integerObjectOf: initialIP).
	self longAt: where + (StackPointerIndex << 2) put: (self integerObjectOf: tempCount).
	self longAt: where + (MethodIndex << 2) put: newMethod.

	"Copy the reciever and arguments..."
	0 to: argumentCount do:
		[:i | self longAt: where + ((ReceiverIndex+i) << 2) put: (self stackValue: argumentCount-i)].

	"clear remaining temps to nil in case it has been recycled"
	nilOop _ nilObj.
	argumentCount+1+ReceiverIndex to: tempCount+ReceiverIndex do:
		[:i | self longAt: where + (i << 2) put: nilOop].

	self pop: argumentCount + 1.
	reclaimableContextCount _ reclaimableContextCount + 1.
	self newActiveContext: newContext.