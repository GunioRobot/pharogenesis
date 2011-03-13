emitForValue: stack on: strm
	super emitForValue: stack on: strm.
	readNode ifNotNil:[readNode emit: stack args: 0 on: strm super: false].