handlesMouseDown: evt
	^ (evt shiftPressed and: [owner wantsKeyboardFocusFor: self])
		ifTrue: [self uncoveredAt: evt cursorPoint]
		ifFalse: [super handlesMouseDown: evt].
