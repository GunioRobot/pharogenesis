fullBounds
	| subBounds |
	fullBounds ifNil:[
		fullBounds _ self bounds.
		submorphs do:[:m|
			subBounds _ (self transform localBoundsToGlobal: m fullBounds).
			fullBounds _ fullBounds quickMerge: subBounds.
		].
	].
	^fullBounds