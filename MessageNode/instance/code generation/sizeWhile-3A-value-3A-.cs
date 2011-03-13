sizeWhile: encoder value: forValue 
	"L1: ... Bfp(L2) ... Jmp(L1) L2: nil (nil for value only);
	justStmt, wholeLoop, justJump."
	| cond stmt stmtSize loopSize branchSize |
	cond := receiver.
	stmt := arguments at: 1.
	stmtSize := (stmt sizeForEvaluatedEffect: encoder) + 2.
	branchSize := self sizeBranchOn: (selector key == #whileFalse:)  "Btp for whileFalse"
					dist: stmtSize.
	loopSize := (cond sizeForEvaluatedValue: encoder)
			+ branchSize + stmtSize.
	sizes := Array with: stmtSize with: loopSize.
	^ loopSize    " +1 for value (push nil) "
		+ (forValue ifTrue: [1] ifFalse: [0])