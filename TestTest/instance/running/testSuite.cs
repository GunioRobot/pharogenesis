testSuite

	| suite result |
	suite := TestSuite new.
	suite addTest: (TestTest selector: #noop).
	suite addTest: (TestTest selector: #fail).
	result := suite run.
	self assert: result runCount = 2.
	self assert: result correctCount = 1.
	self assert: result failureCount = 1.