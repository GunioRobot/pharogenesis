mouseDown: evt
	(owner wantsKeyboardFocusFor: self) ifTrue:
		[evt hand newKeyboardFocus: self]