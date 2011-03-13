sizeIf: encoder value: forValue
	| thenExpr elseExpr branchSize thenSize elseSize |
	thenExpr _ arguments at: 1.
	elseExpr _ arguments at: 2.
	(forValue
		or: [(thenExpr isJust: NodeNil)
		or: [elseExpr isJust: NodeNil]]) not
			"(...not ifTrue: avoids using ifFalse: alone during this compile)"
		ifTrue:  "Two-armed IFs forEffect share a single pop"
			[^ super sizeForEffect: encoder].
	forValue
		ifTrue:  "Code all forValue as two-armed"
			[elseSize _ elseExpr sizeForEvaluatedValue: encoder.
			thenSize _ (thenExpr sizeForEvaluatedValue: encoder)
					+ (thenExpr returns
						ifTrue: [0]  "Elide jump over else after a return"
						ifFalse: [self sizeJump: elseSize]).
			branchSize _ self sizeBranchOn: false dist: thenSize]
		ifFalse:  "One arm is empty here (two-arms code forValue)"
			[(elseExpr isJust: NodeNil)
				ifTrue:
					[elseSize _ 0.
					thenSize _ thenExpr sizeForEvaluatedEffect: encoder.
					branchSize _ self sizeBranchOn: false dist: thenSize]
				ifFalse:
					[thenSize _ 0.
					elseSize _ elseExpr sizeForEvaluatedEffect: encoder.
					branchSize _ self sizeBranchOn: true dist: elseSize]].
	sizes _ Array with: thenSize with: elseSize.
	^ (receiver sizeForValue: encoder) + branchSize
			+ thenSize + elseSize