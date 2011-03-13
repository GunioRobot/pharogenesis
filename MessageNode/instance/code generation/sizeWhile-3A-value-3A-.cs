sizeWhile: encoder value: forValue 
	"L1: ... Bfp(L2) ... Jmp(L1) L2: nil (nil for value only);
	justStmt, wholeLoop, justJump."
	| cond stmt stmtSize loopSize branchSize |
	cond _ receiver.
	stmt _ arguments at: 1.
	stmtSize _ (stmt sizeForEvaluatedEffect: encoder) + 2.
	branchSize _ self sizeBranchOn: (selector key == #whileFalse:)  "Btp for whileFalse"
					dist: stmtSize.
	loopSize _ (cond sizeForEvaluatedValue: encoder)
			+ branchSize + stmtSize.
	sizes _ Array with: stmtSize with: loopSize.
	^ loopSize    " +1 for value (push nil) "
		+ (forValue ifTrue: [1] ifFalse: [0])