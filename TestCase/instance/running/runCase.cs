runCase
	Author
		useAuthor: 'TestRunner'
		during: [
			[self setUp.
			self performTest]
				ensure: [
					self tearDown.
					self cleanUpInstanceVariables ] ]