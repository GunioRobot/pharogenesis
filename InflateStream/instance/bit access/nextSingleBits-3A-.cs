nextSingleBits: n
	| out |
	out _ 0.
	1 to: n do:[:i| out _ (out bitShift: 1) + (self nextBits: 1)].
	^out