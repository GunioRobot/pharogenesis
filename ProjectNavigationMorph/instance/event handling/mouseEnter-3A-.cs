mouseEnter: evt

	(self worldBounds containsPoint: evt cursorPoint) ifFalse: [^self].
	mouseInside _ true.
	self positionVertically.
	