myActiveMorphs
	| out |
	out _ WriteStream on: (Array new: 10).
	activeMorphs do:[:array| out nextPutAll: array].
	^out contents