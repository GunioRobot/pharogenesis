mouseUpFirstPersonControl: evt
	myControls mouseUp: evt.
	myControls setCenter: nil.
	evt hand needsToBeDrawn ifFalse:[Cursor normal show].
