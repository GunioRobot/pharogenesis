typeInTickingRate
	| reply aNumber |
	reply _ FillInTheBlank request: 'Number of ticks per second: ' translated initialAnswer: self tickingRate printString.

	reply ifNotNil:
		[aNumber _ reply asNumber.
		aNumber > 0 ifTrue:
			[self tickingRate: aNumber]]