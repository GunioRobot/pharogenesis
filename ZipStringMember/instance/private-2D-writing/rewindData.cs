rewindData
	super rewindData.
	stream := contents readStream.
	readDataRemaining := contents size