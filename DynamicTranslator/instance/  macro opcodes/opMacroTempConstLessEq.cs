opMacroTempConstLessEq
	"0:PushTemp		1:index1		-- guaranteed SI
	 2:PushConst	3:literal		-- guaranteed SI
	 4:LessOrEqual	5:nil"

	| rcvr arg |
	(self initOp: MacroTempConstLessEq) ifFalse: [
	self beginOp: MacroTempConstLessEq.

		self assertIsIntegerObject: (self peekLiteral: 1).
		rcvr _ self peekInteger: 1.
		rcvr _ self temporary: rcvr.
		(self isIntegerObject: rcvr) ifTrue:
			[rcvr _ self integerValueOf: rcvr.
			 self assertIsIntegerObject: (self peekLiteral: 3).
			 arg _ self peekInteger: 3.
			 rcvr <= arg
				ifTrue: [self internalPush: trueObj]
				ifFalse: [self internalPush: falseObj].
			 self skip: 5.
			^self nextOp].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemp"

	self endOp: MacroTempConstLessEq
	]