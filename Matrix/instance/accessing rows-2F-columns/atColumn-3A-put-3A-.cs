atColumn: column put: aCollection
	|p|

	aCollection size = nrows ifFalse: [self error: 'wrong column size'].
	p _ (self indexForRow: 1 andColumn: column)-ncols.
	aCollection do: [:each | contents at: (p _ p+ncols) put: each].
	^aCollection
