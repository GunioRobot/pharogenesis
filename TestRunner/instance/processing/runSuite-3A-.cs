runSuite: suite
	suite addDependent: self.
	totalTests _ suite tests size.
	completedTests _ 0.
	self installProgressWatcher.
	self runWindow.
	self changed: #runTests.
	self changed: #runOneTest.
	running := true.
 	[ result _ suite run ] ensure: [
		suite removeDependent: self.
		self removeProgressWatcher.
		self updateWindow: result.
		self changed: #runTests.
		self changed: #runOneTest.
	].
