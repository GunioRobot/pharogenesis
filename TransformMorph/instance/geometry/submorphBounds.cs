submorphBounds
	| subBounds |
	subBounds _ nil.
	self submorphsDo:
		[:m |
		subBounds ifNil: [subBounds _ m fullBounds]
				ifNotNil: [subBounds _ subBounds quickMerge: m fullBounds]].
	^ subBounds