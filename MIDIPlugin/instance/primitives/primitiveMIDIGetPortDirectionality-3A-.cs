primitiveMIDIGetPortDirectionality: portNum

	|  dir |
	self primitive: 'primitiveMIDIGetPortDirectionality'
		parameters: #(SmallInteger).
	dir _ self sqMIDIGetPortDirectionality: portNum.
	^dir asSmallIntegerObj