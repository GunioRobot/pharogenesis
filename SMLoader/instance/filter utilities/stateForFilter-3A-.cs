stateForFilter: aFilterSymbol 
	^(self filters includes: aFilterSymbol) ifTrue: ['<yes>'] ifFalse: ['<no>']

