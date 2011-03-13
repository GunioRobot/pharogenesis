stream: aStream
	archive := ZipArchive new readFrom: aStream.
	self setLabel: aStream fullName.
	self memberIndex:  0.
	self changed: #memberList