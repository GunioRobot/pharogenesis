checkBooleanResult: result from: primIndex
	successFlag
		ifTrue: [self pushBool: result]
		ifFalse: [self unPop: 2.  self failSpecialPrim: primIndex]