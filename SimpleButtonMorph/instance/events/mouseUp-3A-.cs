mouseUp: evt
	oldColor ifNotNil:
		["if oldColor nil, it signals that mouse had not gone DOWN
		inside me, e.g. because of a cmd-drag; in this case we want
		to avoid triggering the action!"
		self color: oldColor.
		oldColor _ nil.
		(actWhen == #buttonUp and: [self containsPoint: evt cursorPoint])
			ifTrue: [self doButtonAction]]