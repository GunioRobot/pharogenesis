fullBounds

	fullBounds ifNil: [
		fullBounds _ self bounds.
		submorphs size > 0 ifTrue: [
			submorphs do: [:m | (m visible)
					ifTrue: [fullBounds _ fullBounds quickMerge: m fullBounds]]]].
	^ fullBounds
