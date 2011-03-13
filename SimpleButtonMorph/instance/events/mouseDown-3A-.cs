mouseDown: evt

	| now dt |
	now _ Time millisecondClockValue.
	oldColor _ color. 
	actWhen == #buttonDown
		ifTrue: [self doButtonAction]
		ifFalse: [	self updateVisualState: evt; refreshWorld].
	dt _ Time millisecondClockValue - now max: 0.  "Time it took to do"
	dt < 200 ifTrue: [(Delay forMilliseconds: 200-dt) wait].
	self mouseStillDown: evt.