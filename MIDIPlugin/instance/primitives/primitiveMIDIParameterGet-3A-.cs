primitiveMIDIParameterGet: whichParameter

	|  currentValue |
	"read parameter"
	self primitive: 'primitiveMIDIParameterGet'
		parameters: #(SmallInteger).
	currentValue _ self cCode: 'sqMIDIParameterGet(whichParameter)'.
	^currentValue asSmallIntegerObj