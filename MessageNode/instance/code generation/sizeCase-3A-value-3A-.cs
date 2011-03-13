sizeCase: encoder value: forValue

	| braceNode sizeIndex thenSize elseSize |
	forValue not
		ifTrue: [^super sizeForEffect: encoder].
	equalNode _ encoder encodeSelector: #=.
	braceNode _ arguments first.
	sizes _ Array new: 2 * braceNode numElements.
	sizeIndex _ sizes size.
	elseSize _ arguments size = 2
		ifTrue:
			[arguments last sizeForEvaluatedValue: encoder] "otherwise: [...]"
		ifFalse:
			[caseErrorNode _ encoder encodeSelector: #caseError.
			 1 + (caseErrorNode size: encoder args: 0 super: false)]. "self caseError"
	braceNode casesReverseDo:
		[:keyNode :valueNode :last |
		sizes at: sizeIndex put: elseSize.
		thenSize _ valueNode sizeForEvaluatedValue: encoder.
		valueNode returns ifFalse: [thenSize _ thenSize + (self sizeJump: elseSize)].
		sizes at: sizeIndex-1 put: thenSize.
		last ifFalse: [elseSize _ elseSize + 1]. "Dup"
		elseSize _ elseSize + (keyNode sizeForEvaluatedValue: encoder) +
			(equalNode size: encoder args: 1 super: false) +
			(self sizeBranchOn: false dist: thenSize) + thenSize.
		sizeIndex _ sizeIndex - 2].
	^(receiver sizeForValue: encoder) + elseSize
