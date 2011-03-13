recurrence: rSymbol
	(self validRecurrenceSymbols includes: rSymbol)
		ifFalse: [^ self error: 'unrecognized recurrence symbol: , rSymbol'].
	recurrence _ rSymbol