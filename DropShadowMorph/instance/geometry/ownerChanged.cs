ownerChanged
	super ownerChanged.
	self submorphsDo: [:m | m ownerChanged].
	self computeBounds