handlesMouseDown: evt
	^evt yellowButtonPressed
		or: [super handlesMouseDown: evt]