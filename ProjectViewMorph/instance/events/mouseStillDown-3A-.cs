mouseStillDown: evt

	(self containsPoint: evt cursorPoint) ifFalse: [
		self showMouseState: 3.
		mouseDownTime _ nil.
		^self
	].
	self showMouseState: 2.
	mouseDownTime ifNil: [
		mouseDownTime _ Time millisecondClockValue.
		^self
	].
	((Time millisecondClockValue - mouseDownTime) > 1100) ifFalse: [^self].
				
	self showMenuForProjectView.

					