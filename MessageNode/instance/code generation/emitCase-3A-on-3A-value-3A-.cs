emitCase: stack on: strm value: forValue

	| braceNode sizeStream thenSize elseSize |
	forValue not
		ifTrue: [^super emitForEffect: stack on: strm].
	braceNode := arguments first.
	sizeStream := sizes readStream.
	receiver emitForValue: stack on: strm.
	braceNode casesForwardDo:
		[:keyNode :valueNode :last |
		thenSize := sizeStream next.
		elseSize := sizeStream next.
		last ifFalse: [strm nextPut: Dup. stack push: 1].
		keyNode emitForEvaluatedValue: stack on: strm.
		equalNode emit: stack args: 1 on: strm.
		self emitBranchOn: false dist: thenSize pop: stack on: strm.
		last ifFalse: [strm nextPut: Pop. stack pop: 1].
		valueNode emitForEvaluatedValue: stack on: strm.
		last ifTrue: [stack pop: 1].
		valueNode returns ifFalse: [self emitJump: elseSize on: strm]].
	arguments size = 2
		ifTrue:
			[arguments last emitForEvaluatedValue: stack on: strm] "otherwise: [...]"
		ifFalse:
			[NodeSelf emitForValue: stack on: strm.
			caseErrorNode emit: stack args: 0 on: strm]