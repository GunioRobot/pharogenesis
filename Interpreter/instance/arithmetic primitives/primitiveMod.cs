primitiveMod

	| integerReceiver integerArgument integerResult |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	self success: integerArgument ~= 0.
	successFlag ifFalse: [integerArgument _ 1].  "fall through to fail"
	integerResult _ integerReceiver \\ integerArgument.

	"ensure that the result has the same sign as the argument"
	integerArgument < 0 ifTrue: [
		integerResult > 0
			ifTrue: [integerResult _ integerResult + integerArgument].
	] ifFalse: [
		integerResult < 0
			ifTrue: [integerResult _ integerResult + integerArgument].
	].
	self checkIntegerResult: integerResult from: 11.
