step

	| newBounds |
	target ifNil: [^ self].
	target isWorldMorph
		ifTrue: [newBounds _ target bounds]
		ifFalse: [newBounds _ target renderedMorph worldBoundsForHalo].
	newBounds = self bounds ifTrue: [^ self].
	growingOrRotating ifFalse: [  "adjust halo bounds if appropriate"
		submorphs size > 1
			ifTrue: [self addHandles].  "recreates full set with new bounds"
		self bounds: newBounds].
