testQueryShouldFindWorkingCopy
	| queryReference workingCopy |
	queryReference := GoferConstraintReference name: 'Gofer'.
	workingCopy := queryReference workingCopy.
	self assert: workingCopy packageName = 'Gofer'