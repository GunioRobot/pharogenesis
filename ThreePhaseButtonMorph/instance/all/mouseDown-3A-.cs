mouseDown: evt

	self state: #pressed.
	actWhen == #buttonDown
		ifTrue: [self doButtonAction]