primitiveBlockCopy

	| context methodContext contextSize newContext initialIP |
	context _ self stackValue: 1.
	(self isIntegerObject: (self fetchPointer: MethodIndex ofObject: context)) ifTrue: [
		"context is a block; get the context of its enclosing method"
		methodContext _ self fetchPointer: HomeIndex ofObject: context.
	] ifFalse: [
		methodContext _ context.
	].
	contextSize _ self sizeBitsOf: methodContext.  "in bytes, including header"
	context _ nil.  "context is no longer needed and is not preserved across allocation"

	"remap methodContext in case GC happens during allocation"
	self pushRemappableOop: methodContext.
	newContext _ self instantiateSmallClass: (self splObj: ClassBlockContext)
							   sizeInBytes: contextSize
									   fill: nilObj.
	methodContext _ self popRemappableOop.

	initialIP _ self integerObjectOf: instructionPointer - method.
	"Was instructionPointer + 3, but now it's greater by 
		methodOop + 4 (headerSize) and less by 1 due to preIncrement"

	"Assume: have just allocated a new context; it must be young.
	 Thus, can use uncheck stores. See the comment in fetchContextRegisters."

	self storeWord: InitialIPIndex					ofObject: newContext
		withValue: initialIP.
	self storeWord: InstructionPointerIndex		ofObject: newContext
		withValue: initialIP.
	self storeStackPointerValue: 0				inContext: newContext.
	self storePointerUnchecked: BlockArgumentCountIndex	ofObject: newContext
		withValue: (self stackValue: 0).
	self storePointerUnchecked: HomeIndex		ofObject: newContext
		withValue: methodContext.

	self pop: 2.  "block argument count, rcvr"
	self push: newContext.