showResultSummary

	| message summary |
	message := (self result runCount = self result correctCount)
		ifTrue: [self successMessage]
		ifFalse: [self failureMessage].
	Transcript crtab; show: message.
	summary :=
		self result runCount printString, ' run, ',
		self result failureCount printString, ' failed, ',
		self result errorCount printString, ' errors'.
	Transcript crtab; show: summary.