emitIf: stack on: strm value: forValue
	| thenExpr thenSize elseExpr elseSize |
	thenSize _ sizes at: 1.
	elseSize _ sizes at: 2.
	(forValue not and: [(elseSize*thenSize) > 0])
		ifTrue:  "Two-armed IFs forEffect share a single pop"
			[^ super emitForEffect: stack on: strm].
	thenExpr _ arguments at: 1.
	elseExpr _ arguments at: 2.
	receiver emitForValue: stack on: strm.
	forValue
		ifTrue:  "Code all forValue as two-armed"
			[self emitBranchOn: false dist: thenSize pop: stack on: strm.
			pc _ strm position.
			thenExpr emitForEvaluatedValue: stack on: strm.
			stack pop: 1.  "then and else alternate; they don't accumulate"
			thenExpr returns not
				ifTrue:  "Elide jump over else after a return"
					[self emitJump: elseSize on: strm].
			elseExpr emitForEvaluatedValue: stack on: strm]
		ifFalse:  "One arm is empty here (two-arms code forValue)"
			[thenSize > 0
				ifTrue:
					[self emitBranchOn: false dist: thenSize pop: stack on: strm.
					pc _ strm position.
					thenExpr emitForEvaluatedEffect: stack on: strm]
				ifFalse:
					[self emitBranchOn: true dist: elseSize pop: stack on: strm.
					pc _ strm position.
					elseExpr emitForEvaluatedEffect: stack on: strm]]