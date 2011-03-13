step
	| newBounds |
	target ifNil: [^ self].
	(newBounds _ target fullBoundsInWorld) = self bounds ifTrue: [^ self].
	growingOrRotating ifFalse:
		["adjust halo bounds if appropriate"
		submorphs size > 1 ifTrue:
			[self addHandles "recreates full set with new bounds"].
		self bounds: newBounds]