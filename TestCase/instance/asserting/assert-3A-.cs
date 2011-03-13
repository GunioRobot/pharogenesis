assert: aBoolean

	aBoolean
		ifFalse: [TestResult testFailureException signal: 'Assertion failed'].