handlesMouseDown: evt
	(owner wantsKeyboardFocusFor: self)
		ifTrue:
			[^ self uncoveredAt: evt cursorPoint].
	^ super handlesMouseDown: evt