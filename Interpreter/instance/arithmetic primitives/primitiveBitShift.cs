primitiveBitShift 
	| integerReceiver integerArgument shifted |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popPos32BitInteger.
	successFlag ifTrue: [
		integerArgument >= 0 ifTrue: [
			"Left shift -- must fail if we lose bits beyond 32"
			self success: integerArgument <= 31.
			shifted _ integerReceiver << integerArgument.
			self success: (shifted >> integerArgument) = integerReceiver.
		] ifFalse: [
			"Right shift -- OK to lose bits"
			self success: integerArgument >= -31.
			shifted _ integerReceiver bitShift: integerArgument.
		].
	].
	successFlag
		ifTrue: [self push: (self positive32BitIntegerFor: shifted)]
		ifFalse: [self unPop: 2.  self failSpecialPrim: 17]