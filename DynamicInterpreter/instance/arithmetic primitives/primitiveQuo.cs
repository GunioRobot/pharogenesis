primitiveQuo
	"Rounds negative results towards zero."
	"Note: unlike the other arithmetic primitives, this is called as
	a real send, not as a special byte.  Thus successFlag has already
	been set, and failure is normal, not through failSpecialPrim."
	| rcvr arg result |
	arg _ self popInteger.
	rcvr _ self popInteger.
	self success: arg ~= 0.
	successFlag ifTrue: [
		rcvr > 0 ifTrue: [
			arg > 0 ifTrue: [
				result _ rcvr // arg.
			] ifFalse: [
				result _ 0 - (rcvr // (0 - arg)).
			].
		] ifFalse: [
			arg > 0 ifTrue: [
				result _ 0 - ((0 - rcvr) // arg).
			] ifFalse: [
				result _ (0 - rcvr) // (0 - arg).
			].
		].
		self success: (self isIntegerValue: result)].
	successFlag
		ifTrue: [self pushInteger: result]
		ifFalse: [self unPop: 2]