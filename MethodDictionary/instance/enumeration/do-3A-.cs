do: aBlock 
	tally = 0 ifTrue: [^ self].
	1 to: self basicSize do:
		[:i | (self basicAt: i) == nil ifFalse:
			[aBlock value: (array at: i)]]
