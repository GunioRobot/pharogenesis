opMacroPushTempTemp
	"0:PushTemp		1:index1
	 2:PushTemp	3:index2"

	| index |
	(self initOp: MacroPushTempTemp) ifFalse: [
	self beginOp: MacroPushTempTemp.

		index _ self peekInteger: 1.
		self pushTemporaryVariable: index.
		index _ self peekInteger: 3.
		self pushTemporaryVariable: index.
		self skip: 3.

	self endOp: MacroPushTempTemp
	]