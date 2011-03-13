primitiveMIDIRead

	| array portNum fmt arrayLength bytesRead |
	array		_ self stackValue: 0.
	portNum	_ self stackIntegerValue: 1.
	fmt _ self formatOf: array.
	self success: (fmt >= 8 and: [fmt <= 11]).  "bytes array, not CompiledMethod"
	successFlag ifTrue: [
		arrayLength _ self lengthOf: array.
		bytesRead _ self sqMIDIPort: portNum
			Read: arrayLength
			Into: array + BaseHeaderSize].
	successFlag ifTrue: [
		self pop: 3.  "pop rcvr, portNum, array"
		self pushInteger: bytesRead].
