opMacroTempTempSubTemp
	"0:PushTemp		1:index1
	 2:PushTemp	3:index2
	 4:PrimSubtract	5:nil
	 6:PopStoreTemp 7:index3"

	| tempA tempB |
	(self initOp: MacroTempTempSubTemp) ifFalse: [
	self beginOp: MacroTempTempSubTemp.
		tempA _ self temporary: (self peekInteger: 1).		"index1"
		tempB _ self temporary: (self peekInteger: 3).		"index2"
		(self areIntegers: tempA and: tempB) ifTrue: [
				tempA _ (self integerValueOf: tempA) - (self integerValueOf: tempB).
				(self isIntegerValue: tempA) ifTrue: [
					 self temporary: (self peekInteger: 7) put: (self integerObjectOf: tempA).
					 self skip: 7.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroTempTempSubTemp
	]