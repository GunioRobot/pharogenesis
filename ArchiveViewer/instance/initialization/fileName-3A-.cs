fileName: aString
	archive := ZipArchive new readFrom: aString.
	self setLabel: aString.
	self memberIndex:  0.
	self changed: #memberList