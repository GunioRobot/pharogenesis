opMacroLoopStep
	"0:PushTemp		 1:index
	 2:PushConst	 3:<SmallInteger>		-- guaranteed
	 4:add			 5:nil
	 6:PopTemp		 7:index
	 8:LongJump	 9:offset
	10:nil			11:nil"

	| rcvr arg offset |
	(self initOp: MacroLoopStep) ifFalse: [
	self beginOp: MacroLoopStep.

		rcvr _ self peekInteger: 1.
		rcvr _ self temporary: rcvr.
		(self isIntegerObject: rcvr) ifTrue: [
				rcvr _ self integerValueOf: rcvr.
				arg _ self peekInteger: 3.
				rcvr _ rcvr + arg.
				(self isIntegerValue: rcvr) ifTrue: [
					 rcvr _ self integerObjectOf: rcvr.
					 arg _ self peekInteger: 7.
					 self temporary: arg put: rcvr.
					 offset _ self peekOffset: 9.
					 self jump: (11 * 4) + offset.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroLoopStep
	]