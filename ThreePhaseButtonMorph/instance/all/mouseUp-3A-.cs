mouseUp: evt

	
	(actWhen == #buttonUp and: [self containsPoint: evt cursorPoint])
		ifTrue: [self state: #on.
			self doButtonAction]
		ifFalse: [self state: #off.
			target ifNotNil: [target mouseUpBalk: evt]].
			"Allow owner to keep it selected for radio buttons"
