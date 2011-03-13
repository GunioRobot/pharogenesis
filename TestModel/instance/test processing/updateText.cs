updateText

	self summaryText: ((self result runCount = self result correctCount)
		ifTrue: [self successMessage]
		ifFalse: [self failureMessage]).
	self detailsText:
		self result runCount printString, ' run, ' ,
		self result failureCount printString, ' failed, ',
		self result errorCount printString, ' errors (',
		self duration printString, ' ms)'.