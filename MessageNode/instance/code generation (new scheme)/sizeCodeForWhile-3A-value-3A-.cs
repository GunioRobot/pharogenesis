sizeCodeForWhile: encoder value: forValue 
	"L1: ... Bfp(L2) ... Jmp(L1) L2: nil (nil for value only);
	justStmt, wholeLoop, justJump."
	| cond stmt stmtSize loopSize branchSize |
	cond := receiver.
	stmt := arguments at: 1.
	stmtSize := (stmt sizeCodeForEvaluatedEffect: encoder) + (encoder sizeJumpLong: 1).
	branchSize := self
					sizeCode: encoder
					forBranchOn: selector key == #whileFalse:  "Btp for whileFalse"
					dist: stmtSize.
	loopSize := (cond sizeCodeForEvaluatedValue: encoder) + branchSize + stmtSize.
	sizes := Array with: stmtSize with: loopSize.
	^loopSize + (forValue ifTrue: [encoder sizePushSpecialLiteral: nil] ifFalse: [0])