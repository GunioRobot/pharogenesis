int16: anInteger
	"Store the given signed, 16-bit integer on this (binary) stream."

	| n |
	(anInteger < -16r8000) | (anInteger >= 16r8000)
		ifTrue: [self error: 'outside 16-bit integer range'].

	anInteger < 0
		ifTrue: [n _ 16r10000 + anInteger]
		ifFalse: [n _ anInteger].
	self nextPut: (n digitAt: 2).
	self nextPut: (n digitAt: 1).
