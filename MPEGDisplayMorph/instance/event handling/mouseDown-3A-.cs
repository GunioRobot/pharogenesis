mouseDown: evt 
	evt yellowButtonPressed
		ifTrue: [^ self invokeMenu].
	super mouseDown: evt