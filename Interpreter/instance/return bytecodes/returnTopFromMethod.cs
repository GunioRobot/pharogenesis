returnTopFromMethod

	| cntx val |
	cntx _ self sender.
	val _ self internalStackTop.
	self returnValue: val to: cntx.