runCaseAsFailure: aSemaphore
	[self setUp.
	self openDebuggerOnFailingTestMethod] sunitEnsure: [
		self tearDown.
		aSemaphore signal]