cleanUpPatternHistory

	self patternHistory: (self patternHistory select: [:each |
		((self classPatternFrom: each) ~= self defaultClassPattern)
			or: [(self selectorPatternFrom: each) ~= self defaultSelectorPattern]]).