opMacroUpLoopTest
	"0:PushTemp			1:index1
	 2:PushConst		3:<SmallInteger>			-- SI guaranteed by translator
	 4:LessOrEqual		5:nil
	 6:LongJumpFalse	7:<offset>
	8:<unused>			9:<unused>"

	| temp limit offset |
	(self initOp: MacroUpLoopTest) ifFalse: [
	self beginOp: MacroUpLoopTest.

		temp _ self peekInteger: 1.
		temp _ self temporary: temp.
		(self isIntegerObject: temp) ifTrue: [
			temp _ self integerValueOf: temp.
			limit _ self peekInteger: 3.
			(temp <= limit)
				ifTrue: "don't jump"
					[self skip: 9.
					^self nextOp]
				ifFalse: "take jump"
					[offset _ self peekOffset: 7.
					 self jump: (9 * 4) + offset.		"9 words early for jump"
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"fail: PushTemporary"

	self endOp: MacroUpLoopTest
	]