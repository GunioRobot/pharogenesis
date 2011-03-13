valuesDo: aBlock 
	| value |
	tally = 0 ifTrue: [^ self].
	1 to: self basicSize do:
		[:i | (value := array at: i) == nil
			ifFalse: [aBlock value: value]]