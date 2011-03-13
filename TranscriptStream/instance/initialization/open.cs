open
	| openCount |
	openCount _ 0.
	self dependents do:
		[:d | ((d isKindOf: PluggableTextView) or:
			[d isKindOf: PluggableTextMorph]) ifTrue: [openCount _ openCount + 1]].
	openCount = 0
		ifTrue: [self openLabel: 'Transcript']
		ifFalse: [self openLabel: 'Transcript #' , (openCount+1) printString]