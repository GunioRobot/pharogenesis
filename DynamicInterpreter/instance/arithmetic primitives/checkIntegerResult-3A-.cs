checkIntegerResult: integerResult
	self inline: true.
	(successFlag and: [self isIntegerValue: integerResult])
		ifTrue: [self pushInteger: integerResult]
		ifFalse: [self unPop: 2.  self primitiveFail]