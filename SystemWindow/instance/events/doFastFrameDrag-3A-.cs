doFastFrameDrag: grabPoint
	"Do fast frame dragging from the given point"

	| offset newBounds outerWorldBounds |
	outerWorldBounds := self boundsIn: nil.
	offset := outerWorldBounds origin - grabPoint.
	newBounds := outerWorldBounds newRectButtonPressedDo: [:f | 
		Sensor cursorPoint + offset extent: outerWorldBounds extent].
	Display deferUpdatesIn: Display boundingBox while: [
		self position: (self globalPointToLocal: newBounds topLeft)]