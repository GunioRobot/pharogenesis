archive: aZipArchive
	archive _ aZipArchive.
	self model: aZipArchive.
	self setLabel: 'New Zip Archive'.
	self memberIndex: 0.
	self changed: #memberList