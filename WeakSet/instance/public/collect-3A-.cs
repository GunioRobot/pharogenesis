collect: aBlock
	| each newSet |
	newSet _ self species new: self size.
	tally = 0 ifTrue: [^newSet ].
	1 to: array size do:
		[:index |
			((each _ array at: index) == nil or: [each == flag])
				ifFalse: [newSet add: (aBlock value: each)]
		].
	^newSet