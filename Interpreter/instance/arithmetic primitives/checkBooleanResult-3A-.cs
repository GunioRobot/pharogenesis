checkBooleanResult: result
	successFlag
		ifTrue: [self pushBool: result]
		ifFalse: [self unPop: 2]