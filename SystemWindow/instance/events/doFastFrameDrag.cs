doFastFrameDrag

	| offset newBounds outerWorldBounds |

	outerWorldBounds _ self boundsIn: nil.
	offset _ outerWorldBounds origin - Sensor cursorPoint.
	newBounds _ outerWorldBounds newRectFrom: [:f | 
		Sensor cursorPoint + offset extent: outerWorldBounds extent
	].
	^ self position: (self globalPointToLocal: newBounds topLeft) 