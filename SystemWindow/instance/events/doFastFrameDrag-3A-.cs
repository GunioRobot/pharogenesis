doFastFrameDrag: grabPoint
	"Do fast frame dragging from the given point"

	| offset newBounds outerWorldBounds |
	outerWorldBounds _ self boundsIn: nil.
	offset _ outerWorldBounds origin - grabPoint.
	newBounds _ outerWorldBounds newRectFrom: [:f | 
		Sensor cursorPoint + offset extent: outerWorldBounds extent].
	self position: (self globalPointToLocal: newBounds topLeft); comeToFront