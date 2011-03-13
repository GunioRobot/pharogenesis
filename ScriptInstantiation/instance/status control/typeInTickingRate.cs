typeInTickingRate
	| reply aNumber |
	reply := FillInTheBlank request: 'Number of ticks per second: ' translated initialAnswer: self tickingRate printString.

	reply ifNotNil:
		[aNumber := reply asNumber.
		aNumber > 0 ifTrue:
			[self tickingRate: aNumber]]