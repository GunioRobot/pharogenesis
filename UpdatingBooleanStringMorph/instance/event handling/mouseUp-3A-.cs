mouseUp: evt
	(bounds containsPoint: evt cursorPoint)
		ifTrue:
			[self contentsClipped: (target perform: getSelector) not asString.
			self informTarget]
		ifFalse:
			[Beeper beep].
	self color: Color black