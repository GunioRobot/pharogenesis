mouseUp: evt

	
actWhen == #buttonUp ifTrue: [
		(self containsPoint: evt cursorPoint)
			ifTrue: [self state: #on.
				self doButtonAction]
			ifFalse: [self state: #off.
				target ifNotNil: [target mouseUpBalk: evt]]]
				"Allow owner to keep it selected for radio buttons"
	ifFalse: [super mouseUp: evt]	
		"Allow on:send:to: to set the response to events other than actWhen"