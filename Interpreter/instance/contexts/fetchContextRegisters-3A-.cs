fetchContextRegisters: activeCntx
	"Note: internalFetchContextRegisters: should track changes to this method."

	| tmp |
	self inline: true.
	tmp _ self fetchPointer: MethodIndex ofObject: activeCntx.
	(self isIntegerObject: tmp) ifTrue: [
		"if the MethodIndex field is an integer, activeCntx is a block context"
		tmp _ self fetchPointer: HomeIndex ofObject: activeCntx.
		(tmp < youngStart) ifTrue: [ self beRootIfOld: tmp ].
	] ifFalse: [
		"otherwise, it is a method context and is its own home context"
		tmp _ activeCntx.
	].
	theHomeContext _ tmp.
	receiver _ self fetchPointer: ReceiverIndex ofObject: tmp.
	method _ self fetchPointer: MethodIndex ofObject: tmp.

	"the instruction pointer is a pointer variable equal to
		method oop + ip + BaseHeaderSize
		  -1 for 0-based addressing of fetchByte
		  -1 because it gets incremented BEFORE fetching currentByte"
	tmp _ self quickFetchInteger: InstructionPointerIndex ofObject: activeCntx.
	instructionPointer _ method + tmp + BaseHeaderSize - 2.

	"the stack pointer is a pointer variable also..."
	tmp _ self quickFetchInteger: StackPointerIndex ofObject: activeCntx.
	stackPointer _ activeCntx + BaseHeaderSize + ((TempFrameStart + tmp - 1) * 4).