emitBranchOn:
condition dist: dist pop: stack on: strm
	stack pop: 1.
	dist = 0 ifTrue: [^ strm nextPut: Pop].
	condition
		ifTrue: [self emitLong: dist code: BtpLong on: strm]
		ifFalse: [self emitShortOrLong: dist code: Bfp on: strm]