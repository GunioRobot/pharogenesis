localVisibleSubmorphBounds
	"Answer, in my coordinate system, the bounds of all my visible submorphs (or nil if no visible submorphs)"
	| subBounds |
	subBounds _ nil.
	self submorphsDo: [:m |
		(m visible) ifTrue: [
			subBounds
				ifNil: [subBounds _ m fullBounds copy]
				ifNotNil: [subBounds _ subBounds quickMerge: m fullBounds]]
			].
	^subBounds