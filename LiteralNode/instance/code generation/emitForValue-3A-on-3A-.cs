emitForValue: stack on: strm

	code < 256
		ifTrue: [strm nextPut: code]
		ifFalse: [self emitLong: LoadLong on: strm].
	stack push: 1