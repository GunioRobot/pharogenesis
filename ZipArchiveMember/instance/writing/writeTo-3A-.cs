writeTo: aStream
	self rewindData.
	writeLocalHeaderRelativeOffset _ aStream position.
	self writeLocalFileHeaderTo: aStream.
	self writeDataTo: aStream.
	self refreshLocalFileHeaderTo: aStream.