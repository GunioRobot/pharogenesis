sieve

	| flagsSize flags primeCount i k |
	flagsSize _ 8190.
	flags _ Array new: flagsSize.
	i _ flagsSize.
	[i > 0] whileTrue: [
		flags at: i put: true.
		i _ i - 1.
	].

	primeCount _ 0.
	i _ 2.
	[i <= flagsSize] whileTrue: [
		(flags at: i) ifTrue: [
			primeCount _ primeCount + 1. "i is a prime"
			k _ i + i.
			[k <= flagsSize] whileTrue: [
				flags at: k put: false. "k is not a prime; it is a multiple of i"
				k _ k + i.
			].
		].
		i _ i + 1.
	].

	primeCount ~= 1027 ifTrue: [ self error: 'SieveBenchmark' ].