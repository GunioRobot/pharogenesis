emitLoad: stack on: strm
	rcvrNode emitForValue: stack on: strm.
	fieldDef accessKey ifNotNil:[
		super emitForValue: stack on: strm.
	].