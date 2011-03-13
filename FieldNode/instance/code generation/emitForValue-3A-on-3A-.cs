emitForValue: stack on: aStream
	fieldDef accessKey ifNil:[
		rcvrNode emitForValue: stack on: aStream.
		readNode emit: stack args: 0 on: aStream super: false.
	] ifNotNil:[
		rcvrNode emitForValue: stack on: aStream.
		super emitForValue: stack on: aStream.
		readNode emit: stack args: 1 on: aStream super: false.
	].
