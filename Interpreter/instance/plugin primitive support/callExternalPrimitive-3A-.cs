callExternalPrimitive: functionID
"call the external plugin function identified. In the VM this is an address, see InterpreterSimulator for it's version. dispatc.... is a mcro in the VM C code"
	self dispatchFunctionPointer: functionID