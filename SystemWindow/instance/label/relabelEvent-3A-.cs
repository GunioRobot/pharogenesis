relabelEvent: evt
	^ Preferences clickOnLabelToEdit
		ifFalse:	[self mouseDown: evt]
		ifTrue:	[self relabel]