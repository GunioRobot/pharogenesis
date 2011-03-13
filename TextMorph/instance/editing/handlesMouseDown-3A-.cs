handlesMouseDown: evt
	self isPartsDonor ifTrue: [^ false].
	^true