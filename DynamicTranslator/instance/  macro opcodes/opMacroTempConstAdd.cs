opMacroTempConstAdd
	"0:PushTemp		1:index
	 2:PushConst	3:<SmallInteger>		-- guaranteed
	 4:add			5:nil
	 6:PopTemp		7:index"

	| rcvr arg |
	(self initOp: MacroTempConstAdd) ifFalse: [
	self beginOp: MacroTempConstAdd.

		rcvr _ self peekInteger: 1.
		rcvr _ self temporary: rcvr.
		(self isIntegerObject: rcvr) ifTrue: [
				rcvr _ self integerValueOf: rcvr.
				arg _ self peekInteger: 3.
				rcvr _ rcvr + arg.
				(self isIntegerValue: rcvr) ifTrue: [
					 self internalPush: (self integerObjectOf: rcvr).
					 self skip: 5.
					^self nextOp]].

		self pushTemporaryVariable: (self fetchInteger).		"PushTemporaryVariable"

	self endOp: MacroTempConstAdd
	]