currentSelector: messageName

	currentSelector _ messageName.
	self changed: #currentSelector.
	self setContents.
	self changed: #contents.