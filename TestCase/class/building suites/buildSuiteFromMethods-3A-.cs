buildSuiteFromMethods: testMethods 
	| suite |
	suite _ (TestSuite new)
				name: self name asString;
				yourself.
	^self addToSuite: suite fromMethods: testMethods