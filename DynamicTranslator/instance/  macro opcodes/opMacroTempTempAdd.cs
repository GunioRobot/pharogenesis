opMacroTempTempAdd
	"0:PushTemp		1:index1
	 2:PushTemp	3:index2
	 4:add			5:nil"

	| tempA tempB |
	(self initOp: MacroTempTempAdd) ifFalse: [
	self beginOp: MacroTempTempAdd.

		tempA _ self temporary: (self peekInteger: 1).		"index1"
		tempB _ self temporary: (self peekInteger: 3).		"index2"
		(self areIntegers: tempA and: tempB) ifTrue: [
				tempA _ (self integerValueOf: tempA) + (self integerValueOf: tempB).
				(self isIntegerValue: tempA) ifTrue: [
					 self internalPush: (self integerObjectOf: tempA).
					 self skip: 5.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroTempTempAdd
	]