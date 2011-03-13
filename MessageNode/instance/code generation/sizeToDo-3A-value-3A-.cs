sizeToDo: encoder value: forValue 
	" var _ rcvr. L1: [var <= arg1] Bfp(L2) [block body. var _ var + inc] Jmp(L1) L2: "
	| loopSize initStmt test block incStmt blockSize blockVar initSize limitInit |
	block _ arguments at: 3.
	blockVar _ block firstArgument.
	initStmt _ arguments at: 4.
	test _ arguments at: 5.
	incStmt _ arguments at: 6.
	limitInit _ arguments at: 7.
	initSize _ initStmt sizeForEffect: encoder.
	limitInit == nil
		ifFalse: [initSize _ initSize + (limitInit sizeForEffect: encoder)].
	blockSize _ (block sizeForEvaluatedEffect: encoder)
			+ (incStmt sizeForEffect: encoder) + 2.  "+2 for Jmp backward"
	loopSize _ (test sizeForValue: encoder)
			+ (self sizeBranchOn: false dist: blockSize)
			+ blockSize.
	sizes _ Array with: blockSize with: loopSize.
	^ initSize + loopSize
			+ (forValue ifTrue: [1] ifFalse: [0])    " +1 for value (push nil) "