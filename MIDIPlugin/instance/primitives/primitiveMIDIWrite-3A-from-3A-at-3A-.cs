primitiveMIDIWrite: portNum from: array at: time

	| arrayLength bytesWritten |
	self primitive: 'primitiveMIDIWrite'
		parameters: #(SmallInteger ByteArray SmallInteger).
	arrayLength _ interpreterProxy byteSizeOf: array cPtrAsOop.
	bytesWritten _ self sqMIDIPort: portNum
			Write: arrayLength
			From: array asInteger
			At: time.
	^bytesWritten asSmallIntegerObj