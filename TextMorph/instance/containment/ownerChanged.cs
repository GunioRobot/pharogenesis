ownerChanged
	super ownerChanged.
	container ifNotNil:
		[self releaseParagraph]