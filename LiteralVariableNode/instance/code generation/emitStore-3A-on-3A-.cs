emitStore: stack on: strm
	splNode ifNil:[^super emitStore: stack on: strm].
	splNode
			emit: stack
			args: 1
			on: strm
			super: false.