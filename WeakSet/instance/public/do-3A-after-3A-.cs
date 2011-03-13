do: aBlock after: anElement
	| each startIndex |

	tally = 0 ifTrue: [^self].
	startIndex _ anElement ifNil: [1] ifNotNil:
		[self findElementOrNil: anElement].
	startIndex + 1 to: array size do:
		[:index |
			((each _ array at: index) == nil or: [each == flag])
				ifFalse: [aBlock value: each]
		]