emitStore: stack on: strm
	writeNode ifNil:[^super emitStore: stack on: strm].
	writeNode
			emit: stack
			args: 1
			on: strm
			super: false.