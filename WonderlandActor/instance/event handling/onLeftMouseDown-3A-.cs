onLeftMouseDown: event
	"The default response to left mouse down events"

	(event getCameraMorph) setEventFocus: self.
	(myWonderland getUndoStack) push: (UndoPOVChange for: self from: (self getPointOfView)).

	self respondWith: [:anEvent | self onMouseMove: anEvent] to: mouseMove.
