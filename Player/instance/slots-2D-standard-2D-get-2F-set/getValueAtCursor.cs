getValueAtCursor
	| anObject |
	anObject _ self getValueFromCostume: #valueAtCursor.
	^ anObject == 0  "weird return from GraphMorph"
		ifTrue:
			[nil]
		ifFalse:
			[anObject assuredPlayer]