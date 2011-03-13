mouseMove: evt
	evt shiftPressed ifTrue: [^ self].
	self position: evt targetPoint.
	self updateImage