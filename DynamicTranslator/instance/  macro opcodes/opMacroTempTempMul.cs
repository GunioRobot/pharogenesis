opMacroTempTempMul
	"0:PushTemp		1:index1
	 2:PushTemp	3:index2
	 4:PrimMultiply	5:nil"

	| tempA tempB result |
	(self initOp: MacroTempTempMul) ifFalse: [
	self beginOp: MacroTempTempMul.

		tempA _ self temporary: (self peekInteger: 1).		"index1"
		tempB _ self temporary: (self peekInteger: 3).		"index2"
		(self areIntegers: tempA and: tempB) ifTrue: [
				tempA _ self integerValueOf: tempA.
				tempB _ self integerValueOf: tempB.
				result _ tempA * tempB.
				((tempB = 0 or: [(result // tempB) = tempA]) and: [self isIntegerValue: result]) ifTrue: [
					 self internalPush: (self integerObjectOf: result).
					 self skip: 5.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroTempTempMul
	]