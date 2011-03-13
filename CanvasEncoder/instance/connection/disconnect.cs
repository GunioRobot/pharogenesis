disconnect
	connection ifNotNil: [
		connection destroy.
		connection _ nil.
	].