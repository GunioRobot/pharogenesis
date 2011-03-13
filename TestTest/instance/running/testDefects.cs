testDefects

	| result suite error failure |
	suite := TestSuite new.
	suite addTest: (error := TestTest selector: #error).
	suite addTest: (failure := TestTest selector: #fail).
	result := suite run.
	self assert: result defects asArray = (Array with: error with: failure).