buildSuiteFromMethods: testMethods 
	| suite |
	suite := (TestSuite new)
				name: self name asString;
				yourself.
	^self addToSuite: suite fromMethods: testMethods