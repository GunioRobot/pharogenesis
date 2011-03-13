resetIfDirty
	self current isDirty ifTrue: [self reset]