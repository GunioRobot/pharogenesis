localBounds
	^localBounds ifNil:[localBounds _ self transform globalBoundsToLocal: self bounds]