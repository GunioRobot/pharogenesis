verifyStableContext: t1 
	| t2 t3 t4 t5 |
	t2 _ self fetchPointer: SenderIndex ofObject: t1.
	t2 = nilObj ifFalse: [self assertIsStableContext: t2].
	self assertIsIntegerObject: (self fetchPointer: InstructionPointerIndex ofObject: t1).
	self assertIsIntegerObject: (t3 _ self fetchPointer: StackPointerIndex ofObject: t1).
	t4 _ self fetchPointer: MethodIndex ofObject: t1.
	(self isIntegerObject: t4)
		ifTrue: 
			[t5 _ self fetchPointer: HomeIndex ofObject: t1.
			self assertIsStableMethodContext: t5]
		ifFalse: [self assertIsCompiledMethod: t4].
	t3 _ self integerValueOf: t3.
	t3 < 0 ifTrue: [self error: 'stable stack underflow'].
	t3 > 32 ifTrue: [self error: 'stable stack overflow'].
	self okayFields: t1