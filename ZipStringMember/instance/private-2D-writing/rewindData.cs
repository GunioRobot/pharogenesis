rewindData
	super rewindData.
	stream _ ReadStream on: contents.
	readDataRemaining _ contents size.