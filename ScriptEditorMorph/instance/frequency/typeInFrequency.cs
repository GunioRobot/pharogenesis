typeInFrequency
	| reply aNumber |
	reply _ FillInTheBlank request: 'Number of firings per tick: ' initialAnswer: self scriptInstantiation frequency printString.

	reply ifNotNil:
		[aNumber _ reply asNumber.
		aNumber > 0 ifTrue:
			[self setFrequencyTo: aNumber]]