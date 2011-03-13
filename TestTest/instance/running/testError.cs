testError

	| case result |
	case := TestTest selector: #error.
	result := case run.
	self assert: result correctCount = 0.
	self assert: result failureCount = 0.
	self assert: result runCount = 1.
	self assert: result errorCount = 1.