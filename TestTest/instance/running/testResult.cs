testResult

	| case result |
	case := TestTest selector: #noop.
	result := case run.
	self assert: result runCount = 1.
	self assert: result correctCount = 1.