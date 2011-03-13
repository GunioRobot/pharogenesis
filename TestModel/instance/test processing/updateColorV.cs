updateColorV

	self summaryTextV insideColor: ((self result runCount = self result correctCount)
		ifTrue: [self successColor]
		ifFalse: [self failureColor]).