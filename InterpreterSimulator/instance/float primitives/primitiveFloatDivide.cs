primitiveFloatDivide
	"Note: This method overridden here because the translator (intentionally) doesn't translate the / operator (since the semantics of C / are the semantics of Smalltalk //). This allows the version of this method to be translated to express division as //, which translates to the float division operator /."

	| rcvr arg |
	arg _ self popFloatOnly.
	rcvr _ self popFloatOnly.
	successFlag ifTrue: [self success: arg ~= 0.0].
	successFlag
		ifTrue: [self pushFloat: rcvr / arg]
		ifFalse: [self unPop: 2].