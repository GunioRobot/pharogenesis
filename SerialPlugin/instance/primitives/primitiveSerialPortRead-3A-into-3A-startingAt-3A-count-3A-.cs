primitiveSerialPortRead: portNum into: array startingAt: startIndex count: count 
	| bytesRead arrayPtr |
	self primitive: 'primitiveSerialPortRead'
		parameters: #(SmallInteger ByteArray SmallInteger SmallInteger ).

	interpreterProxy success: (startIndex >= 1 and: [startIndex + count - 1 <= (interpreterProxy byteSizeOf: array cPtrAsOop)]).
	arrayPtr _ array asInteger + startIndex - 1.
	bytesRead _ self cCode: 'serialPortReadInto( portNum, count, arrayPtr)'.
	"adjust for zero-origin indexing"
	^ bytesRead asSmallIntegerObj