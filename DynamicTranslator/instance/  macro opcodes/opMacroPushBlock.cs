opMacroPushBlock
	"	0:MacroPushBlock	1:nil			(PushActiveContext)
		2:PushConstant		3:numArgs
		4:PrimBlockCopy		5:nil
		6:LongJump			7:offset
		8:nil				9:nil"

	"We can do a LOT better than the following.  Consider the current implementation as
	a placeholder for some impending rocket science."

	| offset |
	(self initOp: MacroPushBlock) ifFalse: [
	self beginOp: MacroPushBlock.

		self skip: 5.											"finishing PrimBlockCopy"
		self externalizeIPandSP.
		self push: (self pseudoContextFor: localCP).			"pushActiveContext -- provokes GC"
		localIP _ self
			cCoerce: self internalInstructionPointer			"in case of GC"
			to: 'char *'.
		self push: (self peekLiteral: -2).						"pushLiteral: numArgs"
		successFlag _ true.
		self primitiveBlockCopy.								"pop: 2 thenPush: closure"
		successFlag ifFalse: [
			"ip/sp should be internal, but I don't think it matters"
			self sendSpecialSelector: 24 nArgs: 1.				"ip/sp correct for primitive failure:"
			^self nextOp.									"	return from fail to longJump"
		].
		self internalizeIPandSP.
		offset _ self peekOffset: 2.
		self jump: (2 * 8) + offset.				"tPC is two bytecodes early for longJump"

	self endOp: MacroPushBlock
	]