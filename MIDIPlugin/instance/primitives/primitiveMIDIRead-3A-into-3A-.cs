primitiveMIDIRead: portNum into: array

	| arrayLength bytesRead |
	self primitive: 'primitiveMIDIRead'
		parameters: #(SmallInteger ByteArray).
	arrayLength _ interpreterProxy byteSizeOf: array cPtrAsOop.
	bytesRead _ self sqMIDIPort: portNum
			Read: arrayLength
			Into: array asInteger.
	^bytesRead asSmallIntegerObj