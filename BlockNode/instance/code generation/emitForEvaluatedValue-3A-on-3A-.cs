emitForEvaluatedValue: stack on: aStream
	self emitExceptLast: stack on: aStream.
	statements last emitForValue: stack on: aStream.
	(returns and: [statements size > 1
			and: [(statements at: statements size-1) prefersValue]])
		ifTrue: [stack pop: 1]  "compensate for elided pop prior to return"