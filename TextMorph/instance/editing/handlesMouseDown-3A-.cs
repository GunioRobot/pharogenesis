handlesMouseDown: evt
	(self hasProperty: #partsDonor) ifTrue: [^ false].
	^ self uncoveredAt: evt cursorPoint
