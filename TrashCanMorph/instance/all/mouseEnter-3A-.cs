mouseEnter: evt
	((evt hand submorphCount > 0) and: [evt hand submorphs first ~~ self])
		ifTrue:
		[self world soundsEnabled  ifTrue: [self playMouseEnterSound].
			evt hand startDisplaySuppression.
			self world abandonAllHalos.
			self color: self aboutToTrashColor].
	super mouseEnter: evt.