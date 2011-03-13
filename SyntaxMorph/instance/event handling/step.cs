step
	self isBlockNode ifTrue: [self trackDropZones].
	super step