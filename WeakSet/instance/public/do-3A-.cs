do: aBlock
	| each |

	tally = 0 ifTrue: [^self].
	1 to: array size do:
		[:index |
			((each _ array at: index) == nil or: [each == flag])
				ifFalse: [aBlock value: each]
		]