activateNewMethod

	| newContext fromIndex toIndex lastIndex methodHeader smallContext initialIP tempCount nilOop |
	self inline: false.
	self var: #fromIndex declareC: 'char * fromIndex'.
	self var: #toIndex declareC: 'char * toIndex'.
	self var: #lastIndex declareC: 'char * lastIndex'.

	methodHeader _ self headerOf: newMethod.
	smallContext _ ((methodHeader >> 18) bitAnd: 1) = 0.
	newContext _ self allocateOrRecycleContext: smallContext.

	initialIP _
		((LiteralStart + (self literalCountOfHeader: methodHeader)) * 4) + 1.
	tempCount _
		(methodHeader >> 19) bitAnd: 16r3F.

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

	fromIndex _ (self cCoerce: activeContext to: 'char *') + ((self stackPointerIndex - argumentCount) * 4).
	toIndex _ (self cCoerce: newContext to: 'char *') + (ReceiverIndex * 4).
	lastIndex _ fromIndex + ((argumentCount + 1) * 4).
	[fromIndex < lastIndex] whileTrue: [
		fromIndex _ fromIndex + 4.
		toIndex _ toIndex + 4.
		self longAt: toIndex put: (self longAt: fromIndex).
	].

	"clear remaining context fields to nil in case it has been recycled"
	nilOop _ nilObj.
	smallContext
		ifTrue: [lastIndex _ (self cCoerce: newContext to: 'char *') + SmallContextSize - BaseHeaderSize]
		ifFalse: [lastIndex _ (self cCoerce: newContext to: 'char *') + LargeContextSize - BaseHeaderSize].
	[toIndex < lastIndex] whileTrue: [
		toIndex _ toIndex + 4.
		self longAt: toIndex put: nilOop.
	].

	self pop: argumentCount + 1.
	reclaimableContextCount _ reclaimableContextCount + 1.
	self newActiveContext: newContext.