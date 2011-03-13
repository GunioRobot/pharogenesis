= other
	self species = other species ifFalse: [^ false].
	^ self theClass = other theClass