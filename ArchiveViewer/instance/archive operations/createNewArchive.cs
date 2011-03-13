createNewArchive
	self setLabel: '(new archive)'.
	archive := ZipArchive new.
	self memberIndex: 0.
	self changed: #memberList.