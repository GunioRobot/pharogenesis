addCircleHandles
	| box |
	simpleMode _ false.
	target isWorldMorph ifTrue: [^ self addHandlesForWorldHalos].

	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target renderedMorph worldBoundsForHalo.  "update my size"
	box _ self basicBox.

	target addHandlesTo: self box: box.

	self addName.
	growingOrRotating _ false.
	self layoutChanged.
	self changed.
