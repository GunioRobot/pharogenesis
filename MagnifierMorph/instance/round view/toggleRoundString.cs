toggleRoundString
	^ (self isRound
		ifTrue: ['be square']
		ifFalse: ['be round'])  translated