primitiveMakePoint
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	successFlag
		ifTrue: [self push: (self makePointwithxValue: integerReceiver yValue: integerArgument)]
		ifFalse: [self checkIntegerResult: 0 from: 18  "will fail"]