emitStorePop: stack on: strm
	(self code between: 0 and: 7)
		ifTrue: 
			[strm nextPut: ShortStoP + self code "short stopop inst"]
		ifFalse:
			[(self code between: 16 and: 23)
				ifTrue: [strm nextPut: ShortStoP + 8 + self code - 16 "short stopop temp"]
				ifFalse: [(self code >= 256 and: [self code \\ 256 > 63 and: [self code // 256 = 4]])
						ifTrue: [self emitLong: Store on: strm. strm nextPut: Pop]
						ifFalse: [self emitLong: StorePop on: strm]]].
	stack pop: 1