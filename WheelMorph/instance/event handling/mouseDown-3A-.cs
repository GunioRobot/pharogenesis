mouseDown: evt
	self isHorizontal
		ifTrue: [old := evt cursorPoint x]
		ifFalse: [old := evt cursorPoint y].