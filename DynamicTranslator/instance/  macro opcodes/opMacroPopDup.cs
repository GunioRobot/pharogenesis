opMacroPopDup

	(self initOp: MacroPopDup) ifFalse: [
	self beginOp: MacroPopDup.

		self longAt: localSP put: (self internalStackValue: 1).
		self skip: 3.

	self endOp: MacroPopDup
	]