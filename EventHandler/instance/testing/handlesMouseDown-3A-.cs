handlesMouseDown: evt
	mouseDownRecipient ifNotNil: [^ true].
	mouseStillDownRecipient ifNotNil: [^ true].
	mouseUpRecipient ifNotNil: [^ true].
	^ false