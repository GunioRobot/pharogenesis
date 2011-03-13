mouseDown: evt

	self state: #pressed.
	actWhen == #buttonDown
		ifTrue: [self doButtonAction]
		ifFalse: [super mouseDown: evt].
			"Allow on:send:to: to set the response to events other than actWhen"