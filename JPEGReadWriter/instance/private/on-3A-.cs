on: aStream
	super on: aStream.
	stream _ JPEGReadStream on: stream upToEnd.