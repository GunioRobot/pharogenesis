primitiveMultiply

	| rcvr arg result |
	rcvr _ self stackValue: 1.
	arg _ self stackValue: 0.
	self pop: 2.
	self success: (self areIntegers: rcvr and: arg).
	successFlag ifTrue: [
		rcvr _ self integerValueOf: rcvr.
		arg _ self integerValueOf: arg.
		result _ rcvr * arg.
		"check for C overflow by seeing if computation is reversible"
		self success: ((arg = 0) or: [(result // arg) = rcvr]).
	].
	self checkIntegerResult: result from: 9.