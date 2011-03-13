suite

	| testMethods testSuite |
	testMethods := self selectors select: [:each |
		'test*' match: each].
	testSuite := TestSuite new.
	testMethods do: [:each |
		testSuite addTest: (self selector: each)].
	^testSuite