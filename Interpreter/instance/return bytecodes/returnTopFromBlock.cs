returnTopFromBlock
	"Return to the caller of the method containing the block."

	| cntx val |
	cntx _ self caller.  "Note: caller, not sender!"
	val _ self internalStackTop.
	self returnValue: val to: cntx.