testEnvironmentRemoveKey
	Processor activeProcess environmentAt: #processTests put: 42.
	Processor activeProcess environmentRemoveKey: #processTests.
	self assert: (Processor activeProcess environmentAt: #processTests ifAbsent: []) isNil.
	self should: [Processor activeProcess environmentAt: #processTests] raise: Error