opMacroPushInstTemp
	"0:PushInst		1:index1
	 2:PushTemp	3:index2"

	| index |
	(self initOp: MacroPushInstTemp) ifFalse: [
	self beginOp: MacroPushInstTemp.

		index _ self peekInteger: 1.
		self pushReceiverVariable: index.
		index _ self peekInteger: 3.
		self pushTemporaryVariable: index.
		self skip: 3.

	self endOp: MacroPushInstTemp
	]