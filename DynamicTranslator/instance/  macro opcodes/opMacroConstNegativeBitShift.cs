opMacroConstNegativeBitShift
	"Note: inline constant is a guaranteed SmallInteger [0..31]"
	"0:PushConst			1:integer
	 2:PrimPosBitShift	3:nil"

	| tempA tempB rcvr distance result |
	(self initOp: MacroConstNegativeBitShift) ifFalse: [
	self beginOp: MacroConstNegativeBitShift.

		tempA _ self internalStackTop.
		tempB _ self fetchLiteral.
			(self isIntegerObject: tempA) ifTrue: [
			rcvr _ self integerValueOf: tempA.
			distance _ self integerValueOf: tempB.
			result _ rcvr bitShift: distance.	"ok to lose LS bits"
			self longAt: localSP put: (self integerObjectOf: result).
			self skip: 2.
			^self nextOp].

		self internalPush: tempB.		"PushConstant"

	self endOp: MacroConstNegativeBitShift
	]