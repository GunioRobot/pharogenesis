mouseStillDown: evt

	(self containsPoint: evt cursorPoint) ifFalse: [
		self showMouseState: 3.
		^self
	].
	self showMouseState: 2.
	
	
					