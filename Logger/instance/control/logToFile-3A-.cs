logToFile: fileName
	self close.
	stream _ FileStream newFileNamed: fileName