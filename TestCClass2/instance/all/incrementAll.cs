incrementAll

	| oldVal i |
	oldVal _ vect at: 1.
	i _ VectSize.
	[i > 0] whileTrue: [
		vect at: i put: ((vect at: i) + 1).
		i _ i - 1.
	].
	(vect at: 1) ~= (oldVal + 1) ifTrue: [ self error: 'IncrementAllBenchmark' ].