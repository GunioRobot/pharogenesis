primitiveBitXor
	| integerReceiver integerArgument |
	integerArgument _ self popPos32BitInteger.
	integerReceiver _ self popPos32BitInteger.
	successFlag
		ifTrue: [self push: (self positive32BitIntegerFor:
					(integerReceiver bitXor: integerArgument))]
		ifFalse: [self unPop: 2]