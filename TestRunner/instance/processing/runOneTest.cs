runOneTest
	| testSuite |
	Cursor execute showWhile: [
		self runWindow.
		selectedSuite isZero ifTrue: [ ^ self displayPassFail: 'No Test Suite Selected' ].
		testSuite _  TestSuite new name: 'TestRunner Suite'.
		self addTestsFor: (tests at: selectedSuite) toSuite: testSuite.
		self runSuite: testSuite.
	]