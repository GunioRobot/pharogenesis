primitiveDirectoryDelimitor

	| ascii |
	self export: true.
	ascii _ self asciiDirectoryDelimiter.
	((ascii >= 0) and: [ascii <= 255])
		ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 1.  "pop rcvr"
	interpreterProxy push: (interpreterProxy fetchPointer: ascii ofObject: (interpreterProxy characterTable)).