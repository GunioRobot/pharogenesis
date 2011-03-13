testFail

	| case result |
	case := TestTest selector: #fail.
	result := case run.
	self assert: result correctCount = 0.
	self assert: result failureCount = 1.
	self assert: result runCount = 1.