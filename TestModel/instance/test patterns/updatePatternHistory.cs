updatePatternHistory

	(self patternHistory includes: self patternText)
		ifFalse: [self patternHistory add: self patternText].