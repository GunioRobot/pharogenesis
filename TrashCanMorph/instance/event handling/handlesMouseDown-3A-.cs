handlesMouseDown: evt

	^ self inPartsBin not and: [self uncoveredAt: evt cursorPoint]
