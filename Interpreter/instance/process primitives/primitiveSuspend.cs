primitiveSuspend

	| activeProc |
	activeProc _ self fetchPointer: ActiveProcessIndex
						 ofObject: self schedulerPointer.
	self success: self stackTop = activeProc.
	successFlag ifTrue: [
		self pop: 1.
		self push: nilObj.
		self transferTo: self wakeHighestPriority.
	].