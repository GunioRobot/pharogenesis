xExtendedStoreAndPop
	"	1000010		extendedStoreAndPop {Receiver Temp Illegal Global}[xx] index=yyyyyy
		xxyyyyyy

	=>	ExtendedStoreAndPop
		000000xx
		00yyyyyy
		nil"
	| descriptor variableType index |
	descriptor _ self nextByte.
	variableType _ (descriptor >> 6) bitAnd: 3.
	index _ descriptor bitAnd: 16r3F.
	variableType = 0 ifTrue:
		[self emitOp: ExtendedStoreAndPopReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 1 ifTrue:
		[self emitOp: ExtendedStoreAndPopTemporaryVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 3 ifTrue:
		[self emitOp: ExtendedStoreAndPopLiteralVariable.
		 self emitLiteralVariable: index.
		^self emitSkip: 2].
	self error: 'illegal store in xExtendedStoreAndPop'.