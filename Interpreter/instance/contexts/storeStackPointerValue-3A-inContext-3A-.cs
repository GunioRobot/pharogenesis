storeStackPointerValue: value inContext: contextPointer
	"Assume: value is an integerValue"

	self storeWord: StackPointerIndex
		ofObject: contextPointer
		withValue: (self integerObjectOf: value).