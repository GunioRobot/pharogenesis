mouseLeave: evt
	self lookEnable: #(defaultLook) disable:#(pressLook overLook).
	evt hand needsToBeDrawn ifFalse:[Cursor normal show].
	self executeSounds: #mouseLeave.
	evt anyButtonPressed
		ifTrue:[self executeActions: #mouseLeaveDown]
		ifFalse:[self executeActions: #mouseLeave].