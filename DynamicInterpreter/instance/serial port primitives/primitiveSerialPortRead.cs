primitiveSerialPortRead

	| count startIndex array portNum fmt bytesRead |
	count		_ self stackIntegerValue: 0.
	startIndex	_ self stackIntegerValue: 1.
	array		_ self stackValue: 2.
	portNum	_ self stackIntegerValue: 3.
	fmt _ self formatOf: array.
	self success: (fmt >= 8 and: [fmt <= 11]).  "bytes array, not CompiledMethod"
	self success: (
		(startIndex >= 1) and:
		[(startIndex + count - 1) <= (self lengthOf: array)]).
	successFlag ifTrue: [
		bytesRead _ self serialPort: portNum
			Read: count
			Into: array + BaseHeaderSize + startIndex - 1].  "adjust for zero-origin indexing"
	successFlag ifTrue: [
		self pop: 5.  "pop rcvr, portNum, array, startIndex, count"
		self pushInteger: bytesRead].
