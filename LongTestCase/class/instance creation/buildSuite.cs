buildSuite
	| suite |
	suite _ TestSuite new.
	DoNotRunLongTestCases ifFalse: [
		self addToSuiteFromSelectors: suite].
	^suite