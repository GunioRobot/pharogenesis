primitiveDisableImageWrite
	self export: true.
	self cCode:'ioDisableImageWrite()'.
	interpreterProxy failed ifFalse:[interpreterProxy pop: 1].