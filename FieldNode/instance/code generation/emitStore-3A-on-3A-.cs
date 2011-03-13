emitStore: stack on: strm
	fieldDef accessKey ifNil:[
		writeNode emit: stack args: 1 on: strm super: false.
	] ifNotNil:[
		writeNode emit: stack args: 2 on: strm super: false.
	].