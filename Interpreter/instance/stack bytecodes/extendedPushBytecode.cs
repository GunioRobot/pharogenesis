extendedPushBytecode

	| descriptor variableType variableIndex |
	descriptor _ self fetchByte.
	variableType _ (descriptor >> 6) bitAnd: 16r3.
	variableIndex _ descriptor bitAnd: 16r3F.
	variableType=0 ifTrue: [^self pushReceiverVariable: variableIndex].
	variableType=1 ifTrue: [^self pushTemporaryVariable: variableIndex].
	variableType=2 ifTrue: [^self pushLiteralConstant: variableIndex].
	variableType=3 ifTrue: [^self pushLiteralVariable: variableIndex].