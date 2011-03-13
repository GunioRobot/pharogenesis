copyTraitExpression
	| newCopy |
	newCopy _ self shallowCopy.
	newCopy transformations: (self transformations collect: [ : each | each copyTraitExpression ]).
	^ newCopy
