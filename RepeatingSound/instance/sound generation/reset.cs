reset

	super reset.
	sound reset.
	iterationCount == #forever
		ifTrue: [iteration _ 1]
		ifFalse: [iteration _ iterationCount].
