emitLoad: stack on: strm
	splNode ifNil:[^super emitLoad: stack on: strm].
	self code < 256
		ifTrue: [strm nextPut: self code]
		ifFalse: [self emitLong: LoadLong on: strm].
	stack push: 1.