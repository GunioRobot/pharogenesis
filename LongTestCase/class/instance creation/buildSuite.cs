buildSuite
	| suite |
	suite := TestSuite new.
	DoNotRunLongTestCases ifFalse: [
		self addToSuiteFromSelectors: suite].
	^suite