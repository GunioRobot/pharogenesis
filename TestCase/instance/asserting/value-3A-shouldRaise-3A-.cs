value: aBlockContext shouldRaise: anException

	aBlockContext
		on: anException
		do: [:ex | ^self].
	TestResult testFailureException signal: 'Failed to raise ', anException printString.