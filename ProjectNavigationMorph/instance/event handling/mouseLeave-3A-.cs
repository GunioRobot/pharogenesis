mouseLeave: evt

	self world ifNil: [^self].		"can happen after delete from control menu"
	(self worldBounds containsPoint: evt cursorPoint) ifFalse: [^self].
	mouseInside _ false.
	self positionVertically.
