internalStoreContextRegisters: activeCntx
	"The only difference between this method and fetchContextRegisters: is that this method stores from the local IP and SP."

	"InstructionPointer is a pointer variable equal to
	method oop + ip + BaseHeaderSize
		-1 for 0-based addressing of fetchByte
		-1 because it gets incremented BEFORE fetching currentByte"

	self inline: true.
	self storeWord: InstructionPointerIndex ofObject: activeCntx
		withValue: (self integerObjectOf: (localIP asInteger + 2 - (method + BaseHeaderSize))).
	self storeWord: StackPointerIndex ofObject: activeCntx
		withValue: (self integerObjectOf: (((localSP asInteger - (activeCntx + BaseHeaderSize)) >> 2) - TempFrameStart + 1)).
