emitToDo: stack on: strm value: forValue 
	" var := rcvr. L1: [var <= arg1] Bfp(L2) [block body. var := var + inc] Jmp(L1) L2: "
	| loopSize initStmt limitInit test block incStmt blockSize |
	initStmt := arguments at: 4.
	limitInit := arguments at: 7.
	test := arguments at: 5.
	block := arguments at: 3.
	incStmt := arguments at: 6.
	blockSize := sizes at: 1.
	loopSize := sizes at: 2.
	limitInit == nil
		ifFalse: [limitInit emitForEffect: stack on: strm].
	initStmt emitForEffect: stack on: strm.
	test emitForValue: stack on: strm.
	self emitBranchOn: false dist: blockSize pop: stack on: strm.
	pc := strm position.
	block emitForEvaluatedEffect: stack on: strm.
	incStmt emitForEffect: stack on: strm.
	self emitJump: 0 - loopSize on: strm.
	forValue ifTrue: [strm nextPut: LdNil. stack push: 1]