opMacroConstSub
	"Note: inline constant is a guaranteed SmallInteger"
	"0:PushConst		1:integer
	 2:PrimSub		3:nil"

	| tempA tempB |
	(self initOp: MacroConstSub) ifFalse: [
	self beginOp: MacroConstSub.

		tempA _ self internalStackTop.
		tempB _ self peekInteger: 1.
		(self isIntegerObject: tempA) ifTrue: [
			tempA _ (self integerValueOf: tempA) - tempB.
			(self isIntegerValue: tempA) ifTrue: [
				 self longAt: localSP put: (self integerObjectOf: tempA).
				 self skip: 3.
				^self nextOp]].

		self internalPush: self fetchLiteral.		"PushConstant"

	self endOp: MacroConstSub
	]