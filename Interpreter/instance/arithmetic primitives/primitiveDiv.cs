primitiveDiv
	"Rounds negative results towards negative infinity, rather than zero."
	| rcvr arg result posArg posRcvr |
	successFlag _ true.
	arg _ self popInteger.
	rcvr _ self popInteger.
	self success: arg ~= 0.
	successFlag ifTrue: [
		rcvr > 0 ifTrue: [
			arg > 0 ifTrue: [
				result _ rcvr // arg.
			] ifFalse: [
				"round negative result toward negative infinity"
				posArg _ 0 - arg.
				result _ 0 - ((rcvr + (posArg - 1)) // posArg).
			].
		] ifFalse: [
			posRcvr _ 0 - rcvr.
			arg > 0 ifTrue: [
				"round negative result toward negative infinity"
				result _ 0 - ((posRcvr + (arg - 1)) // arg).
			] ifFalse: [
				posArg _ 0 - arg.
				result _ posRcvr // posArg.
			].
		].
		self checkIntegerResult: result from: 12]
	ifFalse:
		[self checkIntegerResult: 0 from: 12 "will fail"]