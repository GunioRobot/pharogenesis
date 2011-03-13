mouseDown: evt

	oldColor _ color.
	actWhen == #buttonDown
		ifTrue: [self doButtonAction].
