primitiveMakePoint
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	successFlag
		ifTrue: [self push: (self makePointwithxValue: integerReceiver yValue: integerArgument)]
		ifFalse: [self unPop: 2]