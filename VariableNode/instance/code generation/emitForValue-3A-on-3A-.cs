emitForValue: stack on: strm

	code < 256
		ifTrue: 
			[strm nextPut: (code = LdSuper ifTrue: [LdSelf] ifFalse: [code]).
			stack push: 1]
		ifFalse: 
			[self emitLong: LoadLong on: strm.
			stack push: 1]