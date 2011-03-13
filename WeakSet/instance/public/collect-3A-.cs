collect: aBlock
	| each newSet |
	newSet := self species new: self size.
	tally = 0 ifTrue: [^newSet ].
	1 to: array size do:
		[:index |
			((each := array at: index) == nil or: [each == flag])
				ifFalse: [newSet add: (aBlock value: each)]
		].
	^newSet