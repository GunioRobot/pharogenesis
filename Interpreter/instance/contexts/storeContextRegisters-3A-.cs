storeContextRegisters: activeCntx

	"InstructionPointer is a pointer variable equal to
	method oop + ip + BaseHeaderSize
		-1 for 0-based addressing of fetchByte
		-1 because it gets incremented BEFORE fetching currentByte"

	self inline: true.
	self storeWord: InstructionPointerIndex ofObject: activeCntx
		withValue: (self integerObjectOf: 
			(instructionPointer - method - (BaseHeaderSize - 2))).
	self storeWord: StackPointerIndex		  ofObject: activeCntx
		withValue: (self integerObjectOf:
			(self stackPointerIndex - TempFrameStart + 1)).
