checkBooleanResult: result
	self inline: true.
	successFlag
		ifTrue: [self pushBool: result]
		ifFalse: [self unPop: 2]