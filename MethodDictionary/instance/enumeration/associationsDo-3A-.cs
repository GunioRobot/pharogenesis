associationsDo: aBlock 
	| key |
	tally = 0 ifTrue: [^ self].
	1 to: self basicSize do:
		[:i | (key := self basicAt: i) == nil ifFalse:
			[aBlock value: (Association key: key
									value: (array at: i))]]