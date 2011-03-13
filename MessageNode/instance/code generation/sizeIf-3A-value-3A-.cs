sizeIf: encoder value: forValue
	| thenExpr elseExpr branchSize thenSize elseSize |
	thenExpr := arguments at: 1.
	elseExpr := arguments at: 2.
	(forValue
		or: [(thenExpr isJust: NodeNil)
		or: [elseExpr isJust: NodeNil]]) not
			"(...not ifTrue: avoids using ifFalse: alone during this compile)"
		ifTrue:  "Two-armed IFs forEffect share a single pop"
			[^ super sizeForEffect: encoder].
	forValue
		ifTrue:  "Code all forValue as two-armed"
			[elseSize := elseExpr sizeForEvaluatedValue: encoder.
			thenSize := (thenExpr sizeForEvaluatedValue: encoder)
					+ (thenExpr returns
						ifTrue: [0]  "Elide jump over else after a return"
						ifFalse: [self sizeJump: elseSize]).
			branchSize := self sizeBranchOn: false dist: thenSize]
		ifFalse:  "One arm is empty here (two-arms code forValue)"
			[(elseExpr isJust: NodeNil)
				ifTrue:
					[elseSize := 0.
					thenSize := thenExpr sizeForEvaluatedEffect: encoder.
					branchSize := self sizeBranchOn: false dist: thenSize]
				ifFalse:
					[thenSize := 0.
					elseSize := elseExpr sizeForEvaluatedEffect: encoder.
					branchSize := self sizeBranchOn: true dist: elseSize]].
	sizes := Array with: thenSize with: elseSize.
	^ (receiver sizeForValue: encoder) + branchSize
			+ thenSize + elseSize