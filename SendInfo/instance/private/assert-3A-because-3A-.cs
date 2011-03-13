assert: aBlock because: aMessage
	"Throw an assertion error if aBlock does not evaluates to true."

	aBlock value ifFalse: [AssertionFailure signal: aMessage]