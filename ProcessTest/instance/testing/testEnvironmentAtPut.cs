testEnvironmentAtPut
	self assert: (Processor activeProcess environmentAt: #processTests put: 42) = 42.