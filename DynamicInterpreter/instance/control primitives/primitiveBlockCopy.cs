primitiveBlockCopy

	| context methodContext contextSize newContext initialIP cp |

	context _ self stackValue: 1.
	self assertIsContext: context.
	(self isPseudoContext: context) ifTrue: [
		cp _ self pseudoCachedContextAt: context.
		(self isCachedBlockContext: cp) ifTrue: [
			methodContext _ self cachedHomeAt: cp.
		] ifFalse: [
			methodContext _ context.
		].
	] ifFalse: [
		(self isBlockContext: context) ifTrue: [
			methodContext _ self fetchPointer: HomeIndex ofObject: context.
		] ifFalse: [
			methodContext _ context.
		].
	].
	self assertIsContext: methodContext.

	contextSize _ self sizeBitsOf: methodContext.  "in bytes, including header"
	context _ nil.  "context is no longer needed and is not preserved across allocation"

	"remap methodContext in case GC happens during allocation"
	self pushRemappableOop: methodContext.
	newContext _ self instantiateSmallClass: (self splObj: ClassBlockContext)
							   sizeInBytes: contextSize
									   fill: nilObj.
	methodContext _ self popRemappableOop.
	initialIP _ (self translatedInstructionPointer: self instructionPointer
					toIndexIn: self translatedMethod)
				+ (2 * "integer object weighting" 2).
	"Was instructionPointer + 3, but now it's greater by 
		methodOop + 4 (headerSize) and less by 1 due to preIncrement"

	"Assume: have just allocated a new context; it must be young.
	 Thus, can use unchecked stores."

	self storePointerUnchecked: CallerIndex		ofObject: newContext withValue: nilObj.
	self storeWord: InstructionPointerIndex		ofObject: newContext withValue: initialIP.
	self storeWord: StackPointerIndex				ofObject: newContext withValue: ConstZero.
	self storeWord: BlockArgumentCountIndex		ofObject: newContext withValue: (self stackValue: 0).
	self storeWord: InitialIPIndex					ofObject: newContext withValue: initialIP.
	self storePointerUnchecked: HomeIndex		ofObject: newContext withValue: methodContext.

	self pop: 2.  "block argument count, rcvr"
	self push: newContext.