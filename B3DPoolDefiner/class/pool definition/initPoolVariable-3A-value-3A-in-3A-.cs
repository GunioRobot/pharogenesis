initPoolVariable: token value: value in: aDictionary
	aDictionary declare: token from: Undeclared.
	(aDictionary associationAt: token) value: value.