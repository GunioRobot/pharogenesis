returnTopFromBlock
	"Return to the caller of the method containing the block."
	localReturnContext _ self caller.  "Note: caller, not sender!"
	localReturnValue _ self internalStackTop.
	self commonReturn.