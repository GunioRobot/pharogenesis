opMacroMoveTempRcvr
	"0:PushTemp		1:tempIndex
	 2:PopStoreRcvr	3:rcvrIndex"

	| value rcvr |
	(self initOp: MacroMoveTempRcvr) ifFalse: [
	self beginOp: MacroMoveTempRcvr.

		value _ self temporary: (self peekInteger: 1).
		rcvr _ self internalReceiver.
		(rcvr < youngStart) ifTrue: [self possibleRootStoreInto: rcvr value: value].
		self storePointerUnchecked: (self peekInteger: 3) ofObject: rcvr withValue: value.
		self skip: 3.

	self endOp: MacroMoveTempRcvr
	]