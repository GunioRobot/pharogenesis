mouseStillDown: evt

	(visibleMorph containsPoint: evt cursorPoint) ifFalse: [^self].
	nextTimeToFire ifNil: [^self].
	nextTimeToFire <= Time millisecondClockValue ifTrue: [
		self doButtonAction: evt.
		nextTimeToFire _ Time millisecondClockValue + self delayBetweenFirings.
		^self
	].
