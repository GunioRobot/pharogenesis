opMacroConstPositiveBitShift
	"Note: inline constant is a guaranteed SmallInteger [0..31]"
	"0:PushConst			1:integer
	 2:PrimPosBitShift	3:nil"

	| tempA tempB rcvr distance result |
	(self initOp: MacroConstPositiveBitShift) ifFalse: [
	self beginOp: MacroConstPositiveBitShift.

		tempA _ self internalStackTop.
		tempB _ self fetchLiteral.
		(self isIntegerObject: tempA) ifTrue: [
			rcvr _ self integerValueOf: tempA.
			distance _ self integerValueOf: tempB.
			result _ rcvr << distance.
			(((result >> distance) = rcvr) and: [(self isIntegerValue: result) and: [result >= 0]]) ifTrue: [
				self longAt: localSP put: (self integerObjectOf: result).
				self skip: 2.
				^self nextOp]].

		self internalPush: tempB.		"PushConstant"

	self endOp: MacroConstPositiveBitShift
	]