fileName: aString
	archive _ ZipArchive new readFrom: aString.
	self setLabel: aString.
	self memberIndex:  0.
	self changed: #memberList