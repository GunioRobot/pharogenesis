primitiveMIDIGetPortName: portNum

	| portName sz nameObj namePtr |
	self var: #portName declareC: 'char portName[256]'.
	self var: #namePtr declareC: 'char * namePtr'.
	self primitive: 'primitiveMIDIGetPortName'
		parameters: #(SmallInteger).

	sz _ self cCode: 'sqMIDIGetPortName(portNum, (int) &portName, 255)'.
	nameObj _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: sz.
	interpreterProxy failed ifTrue:[^nil].
	namePtr _ nameObj asValue: String .
	self cCode: 'memcpy(namePtr, portName, sz)'.
	^nameObj