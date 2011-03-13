isProbablyPrime: p
	"Answer true if p is prime with very high probability. Such a number is sometimes called an 'industrial grade prime'--a large number that is so extremely likely to be prime that it can assumed that it actually is prime for all practical purposes. This implementation uses the Rabin-Miller algorithm (Schneier, p. 159)."

	| iterations factor pMinusOne b m r a j z couldBePrime |
	iterations _ 50.  "Note: The DSA spec requires >50 iterations; Schneier says 5 are enough (p. 260)"

	"quick elimination: check for p divisible by a small prime"
	SmallPrimes ifNil: [  "generate list of small primes > 2"
		SmallPrimes _ Integer primesUpTo: 2000.
		SmallPrimes _ SmallPrimes copyFrom: 2 to: SmallPrimes size].
	factor _ SmallPrimes detect: [:f | (p \\ f) = 0] ifNone: [nil].
	factor ifNotNil: [^ p = factor].

	pMinusOne _ p - 1.
	b _ self logOfLargestPowerOfTwoDividing: pMinusOne.
	m _ pMinusOne // (2 raisedTo: b).
	"Assert: pMinusOne = m * (2 raisedTo: b) and m is odd"

	Transcript show: '      Prime test pass '.
	r _ Random new.
	1 to: iterations do: [:i |
		Transcript show: i printString; space.
		a _ (r next * 16rFFFFFF) truncated.
		j _ 0.
		z _ (a raisedTo: m modulo: p) normalize.
		couldBePrime _ z = 1.
		[couldBePrime] whileFalse: [
			z = 1 ifTrue: [Transcript show: 'failed!'; cr. ^ false].  "not prime"
			z = pMinusOne
				ifTrue: [couldBePrime _ true]
				ifFalse: [
					(j _ j + 1) < b
						ifTrue: [z _ (z * z) \\ p]
						ifFalse: [Transcript show: 'failed!'; cr. ^ false]]]].  "not prime"

	Transcript show: 'passed!'; cr.
	^ true  "passed all tests; probably prime"
