do: aBlock 
	tally = 0 ifTrue: [^ self].
	1 to: array size do:
		[:index |
		| each |
		(each _ array at: index) ifNotNil: [aBlock value: each]]