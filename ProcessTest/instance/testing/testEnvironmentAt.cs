testEnvironmentAt
	Processor activeProcess environmentAt: #processTests put: 42.
	self assert: (Processor activeProcess environmentAt: #processTests) = 42.
	self should: [Processor activeProcess environmentAt: #foobar] raise: Error