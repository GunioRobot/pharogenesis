skipSeparators
	[self atEnd == false and: [self peek isSeparator]]
		whileTrue: [self next]