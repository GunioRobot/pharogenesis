diagonal: aCollection
	|r i|
	r _ self zeros: aCollection size.
	i _ 0.
	aCollection do: [:each | i _ i+1. r at: i at: i put: each].
	^r