sizeCase: encoder value: forValue

	| braceNode sizeIndex thenSize elseSize |
	forValue not
		ifTrue: [^super sizeForEffect: encoder].
	equalNode := encoder encodeSelector: #=.
	braceNode := arguments first.
	sizes := Array new: 2 * braceNode numElements.
	sizeIndex := sizes size.
	elseSize := arguments size = 2
		ifTrue:
			[arguments last sizeForEvaluatedValue: encoder] "otherwise: [...]"
		ifFalse:
			[caseErrorNode := encoder encodeSelector: #caseError.
			 1 + (caseErrorNode size: encoder args: 0 super: false)]. "self caseError"
	braceNode casesReverseDo:
		[:keyNode :valueNode :last |
		sizes at: sizeIndex put: elseSize.
		thenSize := valueNode sizeForEvaluatedValue: encoder.
		last ifFalse: [thenSize := thenSize + 1]. "Pop"
		valueNode returns ifFalse: [thenSize := thenSize + (self sizeJump: elseSize)].
		sizes at: sizeIndex-1 put: thenSize.
		last ifFalse: [elseSize := elseSize + 1]. "Dup"
		elseSize := elseSize + (keyNode sizeForEvaluatedValue: encoder) +
			(equalNode size: encoder args: 1 super: false) +
			(self sizeBranchOn: false dist: thenSize) + thenSize.
		sizeIndex := sizeIndex - 2].
	^(receiver sizeForValue: encoder) + elseSize
