mouseDown: evt

	super mouseDown: evt.
	mouseDownTime _ Time millisecondClockValue.
	oldColor _ self fillStyle. 
	actWhen == #buttonDown
		ifTrue: [ self doButtonAction]
		ifFalse: [ self updateVisualState: evt ].
	self mouseStillDown: evt.