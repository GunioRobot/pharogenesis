handlesMouseDown: evt
	mouseDownRecipient ifNotNil: [^ true].
	mouseStillDownRecipient ifNotNil: [^ true].
	mouseUpRecipient ifNotNil: [^ true].
	doubleClickRecipient ifNotNil: [^ true].
	^ false