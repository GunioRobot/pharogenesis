toggleFilterState: aFilterSymbol 

	^(self filters includes: (aFilterSymbol)) 
		ifTrue: [self filterRemove: aFilterSymbol]
		ifFalse: [self filterAdd: aFilterSymbol]