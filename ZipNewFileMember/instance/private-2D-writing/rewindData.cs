rewindData
	super rewindData.
	readDataRemaining _ stream size.
	stream position: 0.