handlesMouseDown: evt
	self isPartsDonor ifTrue: [^ false].
	^ self uncoveredAt: evt cursorPoint
