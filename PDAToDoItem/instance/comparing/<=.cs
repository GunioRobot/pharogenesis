<= other

	priority = other priority ifFalse: [^ priority < other priority].
	^ super <= other