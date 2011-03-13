emitStorePop: stack on: strm
	(code between: 0 and: 7)
		ifTrue: 
			[strm nextPut: ShortStoP + code "short stopop inst"]
		ifFalse:
			[(code between: 16 and: 23)
				ifTrue: [strm nextPut: ShortStoP + 8 + code - 16 "short stopop temp"]
				ifFalse: [(code >= 256 and: [code \\ 256 > 63 and: [code // 256 = 4]])
						ifTrue: [self emitLong: Store on: strm. strm nextPut: Pop]
						ifFalse: [self emitLong: StorePop on: strm]]].
	stack pop: 1