bounds

	^computedBounds ifNil: [computedBounds _ self computeBounds]