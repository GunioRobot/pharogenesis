updateColorM

	self summaryTextM color: ((self result runCount = self result correctCount)
		ifTrue: [self successColor]
		ifFalse: [self failureColor]).