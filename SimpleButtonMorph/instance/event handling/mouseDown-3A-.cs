mouseDown: evt

	super mouseDown: evt.
	evt yellowButtonPressed ifTrue: [ ^self ] .
	mouseDownTime _ Time millisecondClockValue.
	oldColor _ self fillStyle. 
	actWhen == #buttonDown
		ifTrue: [ self doButtonAction]
		ifFalse: [ self updateVisualState: evt ].
	self mouseStillDown: evt.