sumFromTo

	| sum i j |
	i _ 10.
	[i > 0] whileTrue: [
		sum _ 0.
		j _ 10000.
		[j > 0] whileTrue: [
			sum _ sum + j.
			j _ j - 1.
		].
		i _ i - 1.
	].
	sum ~= 50005000 ifTrue: [ self error: 'SumFromToBenchmark' ].