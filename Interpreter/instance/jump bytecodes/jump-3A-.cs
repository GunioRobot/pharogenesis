jump: offset

	localIP _ localIP + offset + 1.
	currentBytecode _ self byteAt: localIP.
