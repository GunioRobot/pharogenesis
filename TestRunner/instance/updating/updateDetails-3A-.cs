updateDetails: aTestResult 
	self displayDetails: aTestResult printString
			, (self timeSinceLastPassAsString: aTestResult).
	aTestResult hasPassed
		ifTrue: [lastPass _ Time now]