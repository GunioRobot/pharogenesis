primTestNonSpecificationReturns

	| x y |
	self export: true.
	x _ interpreterProxy stackIntegerValue: 0.
	y _ interpreterProxy stackIntegerValue: 1.
	interpreterProxy pop: 3 thenPush:
		(interpreterProxy integerObjectOf: (x + y)).