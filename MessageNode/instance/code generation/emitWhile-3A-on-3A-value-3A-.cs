emitWhile: stack on: strm value: forValue 
	" L1: ... Bfp(L2)|Btp(L2) ... Jmp(L1) L2: "
	| cond stmt stmtSize loopSize |
	cond _ receiver.
	stmt _ arguments at: 1.
	stmtSize _ sizes at: 1.
	loopSize _ sizes at: 2.
	cond emitForEvaluatedValue: stack on: strm.
	self emitBranchOn: (selector key == #whileFalse:)  "Bfp for whileTrue"
					dist: stmtSize pop: stack on: strm.   "Btp for whileFalse"
	pc _ strm position.
	stmt emitForEvaluatedEffect: stack on: strm.
	self emitJump: 0 - loopSize on: strm.
	forValue ifTrue: [strm nextPut: LdNil. stack push: 1]