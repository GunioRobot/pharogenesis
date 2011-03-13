sizeForStore: encoder
	rcvrNode ifNil:[self encodeReceiverOn: encoder].
	fieldDef accessKey ifNil:[
		writeNode ifNil:[writeNode := encoder encodeSelector: fieldDef toSet].
		^(rcvrNode sizeForValue: encoder) + 
			(writeNode size: encoder args: 1 super: false)	
	].
	writeNode ifNil:[writeNode := encoder encodeSelector: #set:to:].
	^(rcvrNode sizeForValue: encoder) + 
		(super sizeForValue: encoder) +
			(writeNode size: encoder args: 2 super: false)