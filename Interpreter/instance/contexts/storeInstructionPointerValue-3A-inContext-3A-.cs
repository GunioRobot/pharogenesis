storeInstructionPointerValue: value inContext: contextPointer
	"Assume: value is an integerValue"

	self storeWord: InstructionPointerIndex
		ofObject: contextPointer
		withValue: (self integerObjectOf: value).