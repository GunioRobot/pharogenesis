actionsForwarded
	| c |
	c _ OrderedCollection new.
	mouseDownRecipient ifNotNil: [c add: #mouseDown].
	mouseUpRecipient ifNotNil: [c add: #mouseUp].
	mouseStillDownRecipient ifNotNil: [c add: #mouseStillDown].
	mouseEnterRecipient ifNotNil: [c add: #mouseEnter].
	mouseLeaveRecipient ifNotNil: [c add: #mouseLeave].
	keyStrokeRecipient ifNotNil: [c add: #keyStroke].
	^ c