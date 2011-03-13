sizeToDo: encoder value: forValue 
	" var := rcvr. L1: [var <= arg1] Bfp(L2) [block body. var := var + inc] Jmp(L1) L2: "
	| loopSize initStmt test block incStmt blockSize blockVar initSize limitInit |
	block := arguments at: 3.
	blockVar := block firstArgument.
	initStmt := arguments at: 4.
	test := arguments at: 5.
	incStmt := arguments at: 6.
	limitInit := arguments at: 7.
	initSize := initStmt sizeForEffect: encoder.
	limitInit == nil
		ifFalse: [initSize := initSize + (limitInit sizeForEffect: encoder)].
	blockSize := (block sizeForEvaluatedEffect: encoder)
			+ (incStmt sizeForEffect: encoder) + 2.  "+2 for Jmp backward"
	loopSize := (test sizeForValue: encoder)
			+ (self sizeBranchOn: false dist: blockSize)
			+ blockSize.
	sizes := Array with: blockSize with: loopSize.
	^ initSize + loopSize
			+ (forValue ifTrue: [1] ifFalse: [0])    " +1 for value (push nil) "