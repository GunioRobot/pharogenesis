step
	super step.
	self isBlockNode ifTrue: [self trackDropZones].
