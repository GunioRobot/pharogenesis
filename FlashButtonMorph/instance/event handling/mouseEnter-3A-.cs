mouseEnter: evt
	self lookEnable: #(overLook) disable:#(pressLook defaultLook).
	evt hand needsToBeDrawn ifFalse:[Cursor webLink show].
	self executeSounds: #mouseEnter.
	evt anyButtonPressed
		ifTrue:[self executeActions: #mouseEnterDown]
		ifFalse:[self executeActions: #mouseEnter].