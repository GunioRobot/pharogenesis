reset

	super reset.
	sound reset.
	samplesPerIteration _ sound samplesRemaining.
	iterationCount == #forever
		ifTrue: [iteration _ 1]
		ifFalse: [iteration _ iterationCount].
