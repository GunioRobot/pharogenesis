opMacroConstMul
	"Note: inline constant is a guaranteed SmallInteger"
	"0:PushConst		1:integer
	 2:PrimMul		3:nil"

	| tempA tempB result |
	(self initOp: MacroConstMul) ifFalse: [
	self beginOp: MacroConstMul.

		tempA _ self internalStackTop.
		tempB _ self peekInteger: 1.
		(self isIntegerObject: tempA) ifTrue: [
			tempA _ self integerValueOf: tempA.
			result _ tempA * tempB.
			((tempB = 0 or: [(result // tempB) = tempA]) and: [self isIntegerValue: result]) ifTrue: [
				 self longAt: localSP put: (self integerObjectOf: result).
				 self skip: 3.
				^self nextOp]].

		self internalPush: (self fetchLiteral).		"PushConstant"

	self endOp: MacroConstMul
	]