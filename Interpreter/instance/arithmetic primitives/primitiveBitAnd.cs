primitiveBitAnd
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popPos32BitInteger.
	integerReceiver _ self popPos32BitInteger.
	successFlag
		ifTrue: [self push: (self positive32BitIntegerFor:
					(integerReceiver bitAnd: integerArgument))]
		ifFalse: [self unPop: 2.  self failSpecialPrim: 14]