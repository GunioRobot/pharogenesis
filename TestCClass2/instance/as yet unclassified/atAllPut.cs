atAllPut

	| i |
	i _ VectSize.
	[i > 0] whileTrue: [
		vect at: i put: 5.
		i _ i - 1.
	].
	(vect at: 1) ~= 5 ifTrue: [ self error: 'AtAllPutBenchmark' ].