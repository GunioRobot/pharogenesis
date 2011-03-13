value: aBlockContext shouldntRaise: anException

	aBlockContext
		on: anException
		do: [:ex | TestResult testFailureException
			signal: 'Should not raise ', anException printString].