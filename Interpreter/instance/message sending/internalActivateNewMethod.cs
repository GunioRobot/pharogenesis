internalActivateNewMethod
	| methodHeader newContext tempCount argCount2 needsLarge where |
	self inline: true.

	methodHeader _ self headerOf: newMethod.
	needsLarge _ methodHeader bitAnd: LargeContextBit.
	(needsLarge = 0 and: [freeContexts ~= NilContext])
		ifTrue: [newContext _ freeContexts.
				freeContexts _ self fetchPointer: 0 ofObject: newContext]
		ifFalse: ["Slower call for large contexts or empty free list"
				self externalizeIPandSP.
				newContext _ self allocateOrRecycleContext: needsLarge.
				self internalizeIPandSP].
	tempCount _ (methodHeader >> 19) bitAnd: 16r3F.

	"Assume: newContext will be recorded as a root if necessary by the
	 call to newActiveContext: below, so we can use unchecked stores."
	where _   newContext + BaseHeaderSize.
	self longAt: where + (SenderIndex << 2) put: activeContext.
	self longAt: where + (InstructionPointerIndex << 2) put: (self integerObjectOf:
			(((LiteralStart + (self literalCountOfHeader: methodHeader)) * 4) + 1)).
	self longAt: where + (StackPointerIndex << 2) put: (self integerObjectOf: tempCount).
	self longAt: where + (MethodIndex << 2) put: newMethod.

	"Copy the reciever and arguments..."
	argCount2 _ argumentCount.
	0 to: argCount2 do:
		[:i | self longAt: where + ((ReceiverIndex+i) << 2) put: (self internalStackValue: argCount2-i)].

	"clear remaining temps to nil in case it has been recycled"
	methodHeader _ nilObj.  "methodHeader here used just as faster (register?) temp"
	argCount2+1+ReceiverIndex to: tempCount+ReceiverIndex do:
		[:i | self longAt: where + (i << 2) put: methodHeader].

	self internalPop: argCount2 + 1.
	reclaimableContextCount _ reclaimableContextCount + 1.
	self internalNewActiveContext: newContext.
 