doFastFrameDrag

	| offset newBounds |

	offset _ self position - Sensor cursorPoint.
	newBounds _ self bounds newRectFrom: [:f | 
		Sensor cursorPoint + offset extent: self extent
	].
	^ self position: newBounds topLeft