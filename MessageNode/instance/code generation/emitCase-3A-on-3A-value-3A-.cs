emitCase: stack on: strm value: forValue

	| braceNode sizeStream thenSize elseSize |
	forValue not
		ifTrue: [^super emitForEffect: stack on: strm].
	braceNode _ arguments first.
	sizeStream _ ReadStream on: sizes.
	receiver emitForValue: stack on: strm.
	braceNode casesForwardDo:
		[:keyNode :valueNode :last |
		thenSize _ sizeStream next.
		elseSize _ sizeStream next.
		last ifFalse: [strm nextPut: Dup. stack push: 1].
		keyNode emitForEvaluatedValue: stack on: strm.
		equalNode emit: stack args: 1 on: strm.
		self emitBranchOn: false dist: thenSize pop: stack on: strm.
		valueNode emitForEvaluatedValue: stack on: strm.
		stack pop: 1.
		valueNode returns ifFalse: [self emitJump: elseSize on: strm]].
	arguments size = 2
		ifTrue:
			[arguments last emitForEvaluatedValue: stack on: strm] "otherwise: [...]"
		ifFalse:
			[NodeSelf emitForValue: stack on: strm.
			caseErrorNode emit: stack args: 0 on: strm]