mouseUp: evt
	super mouseUp: evt.
	 (self containsPoint: evt cursorPoint) 
		ifFalse: [self mouseLeave: evt .
				" In the case of a balk,
				 we must also note that we have left
				 after color has been restored." ].
