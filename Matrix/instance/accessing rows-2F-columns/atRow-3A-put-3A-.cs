atRow: row put: aCollection
	|p|

	aCollection size = ncols ifFalse: [self error: 'wrong row size'].
	p _ (self indexForRow: row andColumn: 1)-1.
	aCollection do: [:each | contents at: (p _ p+1) put: each].
	^aCollection