step
	(stepNumber _ stepNumber + 1) <= nSteps
		ifTrue: [self changed]
		ifFalse: [self completeReplacement]