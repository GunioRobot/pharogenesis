emitStorePop: stack on: strm
	splNode ifNil:[^super emitStorePop: stack on: strm].
	self emitStore: stack on: strm.
	strm nextPut: Pop.
	stack pop: 1.