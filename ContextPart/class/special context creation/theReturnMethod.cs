theReturnMethod

	| meth |
	meth _ self lookupSelector: #return:.
	meth primitive = 0 ifFalse: [^ self error: 'expected #return: to not be a primitive'].
	^ meth