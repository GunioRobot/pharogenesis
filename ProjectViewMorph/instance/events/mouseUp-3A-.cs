mouseUp: evt
	(self containsPoint: evt cursorPoint) ifTrue:
		[^ self enter].
	self showBorderAs: Color gray
