primitiveBitXor
	"Note: unlike all the other arithmetic primitives, this is called as
	a real send, not as a special byte.  Thus successFlag has already
	been set, and failure is normal, not through failSpecialPrim."
	| integerReceiver integerArgument |
	integerArgument _ self popPos32BitInteger.
	integerReceiver _ self popPos32BitInteger.
	successFlag
		ifTrue: [self push: (self positive32BitIntegerFor:
					(integerReceiver bitXor: integerArgument))]
		ifFalse: [self unPop: 2]