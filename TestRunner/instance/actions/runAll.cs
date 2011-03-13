runAll
	Author
		useAuthor: 'TestRunner'
		during: [
			self reset; runSuite: self suiteAll.
			self saveResultInHistory ]