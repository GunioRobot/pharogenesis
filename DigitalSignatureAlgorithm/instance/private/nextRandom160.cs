nextRandom160
	"Answer a newly generated 160-bit random number in the range [1..(2^160 - 1)]."
	"Details: Try again in the extremely unlikely chance that zero is encountered."

	| result |
	result _ 0.
	[result = 0] whileTrue: [
		result _ SecureHashAlgorithm new hashInteger: randKey seed: randSeed.
		randKey _ randKey + result + 1].
	^ result
