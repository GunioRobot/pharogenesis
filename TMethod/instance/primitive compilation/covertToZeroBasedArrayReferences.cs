covertToZeroBasedArrayReferences
	"Replace the index expressions in at: and at:put: messages with (<expr> - 1), since C uses zero-based array indexing."

	| oldIndexExpr newIndexExpr |
	parseTree nodesDo: [ :n |
		(n isSend and: [(n selector = #at:) or: [ n selector = #at:put: ]]) ifTrue: [
			oldIndexExpr _ n args first.
			oldIndexExpr isConstant ifTrue: [
				"index expression is a constant: decrement the constant now"
				newIndexExpr _ TConstantNode new setValue: (n args first value - 1).
			] ifFalse: [
				"index expression is complex: build an expression to decrement result at runtime"
				newIndexExpr _ TSendNode new
					setSelector: #-
					receiver: oldIndexExpr
					arguments: (Array with: (TConstantNode new setValue: 1)).
			].
			n args at: 1 put: newIndexExpr.
		].
	].
