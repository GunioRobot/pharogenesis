handlesMouseDown: evt
	^ (evt shiftPressed and: [self wantsKeyboardFocusOnShiftClick])
		ifTrue: [self uncoveredAt: evt cursorPoint]
		ifFalse: [super handlesMouseDown: evt].
