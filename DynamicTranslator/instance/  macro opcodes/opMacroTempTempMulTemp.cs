opMacroTempTempMulTemp
	"0:PushTemp		1:index1
	 2:PushTemp	3:index2
	 4:PrimMultiply	5:nil
	 6:PopStoreTemp 7:index3"

	| tempA tempB result |
	(self initOp: MacroTempTempMulTemp) ifFalse: [
	self beginOp: MacroTempTempMulTemp.
		tempA _ self temporary: (self peekInteger: 1).		"index1"
		tempB _ self temporary: (self peekInteger: 3).		"index2"
		(self areIntegers: tempA and: tempB) ifTrue: [
				tempA _ self integerValueOf: tempA.
				tempB _ self integerValueOf: tempB.
				result _ tempA * tempB.
				((tempB = 0 or: [(result // tempB) = tempA]) and: [self isIntegerValue: result]) ifTrue: [
					 self temporary: (self peekInteger: 7) put: (self integerObjectOf: result).
					 self skip: 7.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroTempTempMulTemp
	]