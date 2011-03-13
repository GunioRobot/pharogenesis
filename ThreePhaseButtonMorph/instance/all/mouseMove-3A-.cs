mouseMove: evt

(self containsPoint: evt cursorPoint)
	ifTrue: [self state: #pressed.
			actWhen == #whilePressed 
				ifTrue: [self doButtonAction]
				ifFalse: [super mouseMove: evt]]	
					"Allow on:send:to: to set the response to events other than actWhen"
	ifFalse: [self state: #off].
