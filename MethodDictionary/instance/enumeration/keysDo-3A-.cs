keysDo: aBlock 
	| key |
	tally = 0 ifTrue: [^ self].
	1 to: self basicSize do:
		[:i | (key _ self basicAt: i) == nil
			ifFalse: [aBlock value: key]]