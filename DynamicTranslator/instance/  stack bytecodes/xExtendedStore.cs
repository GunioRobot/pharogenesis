xExtendedStore
	"	1000001		extendedStore {Receiver Temp Illegal Global}[xx] index=yyyyyy
		xxyyyyyy

	=>	ExtendedStore{Receiver,Temp,Literal}Variable
		{index,index,association}
		nil
		nil"

	| descriptor variableType index |
	descriptor _ self nextByte.
	variableType _ (descriptor >> 6) bitAnd: 3.
	index _ descriptor bitAnd: 16r3F.
	variableType = 0 ifTrue:
		[self emitOp: ExtendedStoreReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 1 ifTrue:
		[self emitOp: ExtendedStoreTemporaryVariable.
		 self emitInteger: index.
		^self emitSkip: 2].
	variableType = 3 ifTrue:
		[self emitOp: ExtendedStoreLiteralVariable.
		 self emitLiteralVariable: index.
		^self emitSkip: 2].
	self error: 'illegal store in xExtendedStore'.