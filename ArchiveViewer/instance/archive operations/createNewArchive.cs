createNewArchive
	self setLabel: '(new archive)'.
	archive _ ZipArchive new.
	self memberIndex: 0.
	self changed: #memberList.