mouseUp: evt
	(bounds containsPoint: evt cursorPoint)
		ifTrue:
			[self contentsClipped: (target perform: getSelector) not asString.
			self informTarget]
		ifFalse:
			[self beep].
	self color: Color black