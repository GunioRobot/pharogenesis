mouseLeave: evt
	((evt hand submorphCount > 0) and: [evt hand submorphs first ~~ self]) 
		ifTrue:
			[self world soundsEnabled  ifTrue: [self playMouseLeaveSound].
			evt hand endDisplaySuppression.
			self color: self normalColor].
	super mouseLeave: evt.
	