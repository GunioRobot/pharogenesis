mouseDown: evt

	| now dt |
	oldColor _ color.
	now _ Time millisecondClockValue.
	actWhen == #buttonDown
		ifTrue: [self doButtonAction].
	dt _ Time millisecondClockValue - now max: 0.  "Time it took to do"
	dt < 200 ifTrue: [(Delay forMilliseconds: 200-dt) wait]
