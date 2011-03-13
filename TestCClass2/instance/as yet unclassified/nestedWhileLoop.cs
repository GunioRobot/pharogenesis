nestedWhileLoop

	| sum i j |
	sum _ 0.
	i _ 1000.
	[i > 0] whileTrue: [
		j _ 100.
		[j > 0] whileTrue: [
			sum _ sum + 1.
			j _ j - 1.
		].
		i _ i - 1.
	].
	sum ~= 100000 ifTrue: [ self error: 'NestedWhileBenchmark' ].