opMacroConstBitOr
	"Note: inline constant is a guaranteed SmallInteger"
	"0:PushConst		1:integer
	 2:PrimBitOr		3:nil"

	| tempA tempB |
	(self initOp: MacroConstBitOr) ifFalse: [
	self beginOp: MacroConstBitOr.

		tempA _ self internalStackTop.
		tempB _ self fetchLiteral.
			(self isIntegerObject: tempA) ifTrue: [
			self longAt: localSP put: (tempA bitOr: tempB).
			self skip: 2.
			^self nextOp].

		self internalPush: tempB.		"PushConstant"

	self endOp: MacroConstBitOr
	]