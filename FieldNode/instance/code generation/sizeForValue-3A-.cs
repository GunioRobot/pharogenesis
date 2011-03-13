sizeForValue: encoder
	rcvrNode ifNil:[self encodeReceiverOn: encoder].
	fieldDef accessKey ifNil:[
		readNode ifNil:[readNode := encoder encodeSelector: fieldDef toGet].
		^(rcvrNode sizeForValue: encoder) + 
			(readNode size: encoder args: 0 super: false)
	].
	readNode ifNil:[readNode := encoder encodeSelector: #get:].
	^(rcvrNode sizeForValue: encoder) + 
		(super sizeForValue: encoder) + 
			(readNode size: encoder args: 1 super: false)