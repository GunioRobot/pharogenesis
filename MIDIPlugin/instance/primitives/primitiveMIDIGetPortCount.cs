primitiveMIDIGetPortCount

	| n |
	self primitive: 'primitiveMIDIGetPortCount'.
	n _ self sqMIDIGetPortCount.
	^n asSmallIntegerObj
