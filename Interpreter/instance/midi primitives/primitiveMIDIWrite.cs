primitiveMIDIWrite

	| time array portNum fmt arrayLength bytesWritten |
	time		_ self stackIntegerValue: 0.
	array		_ self stackValue: 1.
	portNum	_ self stackIntegerValue: 2.
	fmt _ self formatOf: array.
	self success: (fmt >= 8 and: [fmt <= 11]).  "bytes array, not CompiledMethod"
	successFlag ifTrue: [
		arrayLength _ self lengthOf: array.
		bytesWritten _ self sqMIDIPort: portNum
			Write: arrayLength
			From: array + BaseHeaderSize
			At: time].
	successFlag ifTrue: [
		self pop: 4.  "pop rcvr, portNum, array, time"
		self pushInteger: bytesWritten].
