emitWhile: stack on: strm value: forValue 
	" L1: ... Bfp(L2)|Btp(L2) ... Jmp(L1) L2: "
	| cond stmt stmtSize loopSize |
	cond := receiver.
	stmt := arguments at: 1.
	stmtSize := sizes at: 1.
	loopSize := sizes at: 2.
	cond emitForEvaluatedValue: stack on: strm.
	self emitBranchOn: (selector key == #whileFalse:)  "Bfp for whileTrue"
					dist: stmtSize pop: stack on: strm.   "Btp for whileFalse"
	pc := strm position.
	stmt emitForEvaluatedEffect: stack on: strm.
	self emitJump: 0 - loopSize on: strm.
	forValue ifTrue: [strm nextPut: LdNil. stack push: 1]