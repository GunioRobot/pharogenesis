primitiveQuo
	"Rounds negative results towards zero."
	| integerRcvr integerArg integerResult |
	integerRcvr _ self stackIntegerValue: 1.
	integerArg _ self stackIntegerValue: 0.
	self success: integerArg ~= 0.
	successFlag ifTrue: [
		integerRcvr > 0 ifTrue: [
			integerArg > 0 ifTrue: [
				integerResult _ integerRcvr // integerArg.
			] ifFalse: [
				integerResult _ 0 - (integerRcvr // (0 - integerArg)).
			].
		] ifFalse: [
			integerArg > 0 ifTrue: [
				integerResult _ 0 - ((0 - integerRcvr) // integerArg).
			] ifFalse: [
				integerResult _ (0 - integerRcvr) // (0 - integerArg).
			].
		]].
	self pop2AndPushIntegerIfOK: integerResult