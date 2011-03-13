myActiveMorphs
	| out |
	out := WriteStream on: (Array new: 10).
	activeMorphs do:[:array| out nextPutAll: array].
	^out contents