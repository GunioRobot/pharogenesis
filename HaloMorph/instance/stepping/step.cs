step

	| newBounds |
	target ifNil: [^ self].
	target isWorldMorph
		ifTrue: [newBounds _ target bounds]
		ifFalse: [newBounds _ self localHaloBoundsFor: target renderedMorph].
	newBounds = self bounds ifTrue: [^ self].
	newBounds extent = self bounds extent ifTrue:[^self position: newBounds origin].
	growingOrRotating ifFalse: [  "adjust halo bounds if appropriate"
		submorphs size > 1
			ifTrue: [self addHandles].  "recreates full set with new bounds"
		self bounds: newBounds].
