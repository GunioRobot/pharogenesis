xExtendedPush
	"	1000000		extendedPush {Receiver Temp LiteralConst Global}[xx] index=yyyyyy
		xxyyyyyy

	=>	ExtendedPush{ReceiverVar,TempVar,Const,LiteralVar}
		{index, index, literal, association}
		nil
		nil"

	| descriptor variableType index |
	descriptor _ self nextByte.
	variableType _ (descriptor >> 6) bitAnd: 3.
	index _ descriptor bitAnd: 16r3F.
	variableType = 0 ifTrue:
		[self emitOp: ExtendedPushReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 1 ifTrue:
		[self emitOp: ExtendedPushTemporaryVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 2 ifTrue:
		[self emitOp: ExtendedPushConstant.
		 self emitLiteralConstant: index.
		^self emitSkip: 2].
	variableType = 3 ifTrue:
		[self emitOp: ExtendedPushLiteralVariable.
		 self emitLiteralVariable: index.
		^self emitSkip: 2].
	self error: 'bad type in xExtendedPush'.