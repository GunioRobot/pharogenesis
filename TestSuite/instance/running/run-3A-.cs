run: aTestResult

	self tests do: [:each |
		each run: aTestResult].