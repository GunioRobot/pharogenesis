runTests
	| suite |
	Cursor execute showWhile: [
		suite _ TestSuite new name: 'TestRunner Suite'.
		self selectedTests do: [ :ea | self addTestsFor: ea toSuite: suite ].
		self runSuite: suite.
	]
