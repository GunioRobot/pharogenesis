checkIntegerResult: integerResult from: primIndex
	(successFlag and: [self isIntegerValue: integerResult])
		ifTrue: [self pushInteger: integerResult]
		ifFalse: [self unPop: 2.  self failSpecialPrim: primIndex]