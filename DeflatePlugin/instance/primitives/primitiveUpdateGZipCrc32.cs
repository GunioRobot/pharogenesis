primitiveUpdateGZipCrc32
	"Primitive. Update a 32bit CRC value."
	| collection stopIndex startIndex crc length bytePtr |
	self export: true.
	self var: #crc declareC:'unsigned int crc'.
	self var: #bytePtr declareC:'unsigned char *bytePtr'.
	self var: #crcTable declareC:'unsigned int *crcTable'.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	collection _ interpreterProxy stackObjectValue: 0.
	stopIndex _ interpreterProxy stackIntegerValue: 1.
	startIndex _ interpreterProxy stackIntegerValue: 2.
	crc _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 3).
	interpreterProxy failed ifTrue:[^0].
	((interpreterProxy isBytes: collection) and:[stopIndex >= startIndex and:[startIndex > 0]])
		ifFalse:[^interpreterProxy primitiveFail].
	length _ interpreterProxy byteSizeOf: collection.
	(stopIndex <= length) ifFalse:[^interpreterProxy primitiveFail].
	bytePtr _ interpreterProxy firstIndexableField: collection.
	self cCode:'' inSmalltalk:[zipCrcTable _ CArrayAccessor on: GZipWriteStream crcTable].
	startIndex _ startIndex - 1.
	stopIndex _ stopIndex - 1.
	startIndex to: stopIndex do:[:i|
		crc _ (zipCrcTable at: ((crc bitXor: (bytePtr at: i)) bitAnd: 255)) bitXor: (crc >> 8).
	].
	interpreterProxy pop: 5. "args + rcvr"
	interpreterProxy push: (interpreterProxy positive32BitIntegerFor: crc).