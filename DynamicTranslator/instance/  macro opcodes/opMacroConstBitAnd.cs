opMacroConstBitAnd
	"Note: inline constant is a guaranteed SmallInteger"
	"0:PushConst		1:integer
	 2:PrimBitAnd	3:nil"

	| tempA tempB |
	(self initOp: MacroConstBitAnd) ifFalse: [
	self beginOp: MacroConstBitAnd.

		tempA _ self internalStackTop.
		tempB _ self fetchLiteral.
			(self isIntegerObject: tempA) ifTrue: [
			self longAt: localSP put: (tempA bitAnd: tempB).
			self skip: 2.
			^self nextOp].

		self internalPush: tempB.		"PushConstant"

	self endOp: MacroConstBitAnd
	]