sumAll

	| elementVal sum i |
	elementVal _ vect at: 1.
	sum _ 0.
	i _ VectSize.
	[i > 0] whileTrue: [
		sum _ sum + (vect at: i).
		i _ i - 1.
	].
	sum ~= (VectSize * elementVal) ifTrue: [ self error: 'SumAllBenchmark' ].