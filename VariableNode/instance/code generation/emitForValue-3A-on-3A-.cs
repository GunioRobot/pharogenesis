emitForValue: stack on: strm

	self code < 256
		ifTrue: 
			[strm nextPut: (self code = LdSuper ifTrue: [LdSelf] ifFalse: [self code]).
			stack push: 1]
		ifFalse: 
			[self emitLong: LoadLong on: strm.
			stack push: 1]