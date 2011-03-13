emitStorePop: stack on: strm
	writeNode ifNil:[^super emitStorePop: stack on: strm].
	self emitStore: stack on: strm.
	strm nextPut: Pop.
	stack pop: 1.