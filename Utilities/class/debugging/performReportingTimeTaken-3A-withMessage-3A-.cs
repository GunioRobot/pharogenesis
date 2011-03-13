performReportingTimeTaken: aBlock withMessage: aString
	self showInTranscript:  aString, ' ', ((Time millisecondsToRun: aBlock) // 1000) printString, ' seconds.'