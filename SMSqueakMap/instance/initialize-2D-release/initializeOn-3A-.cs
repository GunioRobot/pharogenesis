initializeOn: directoryName
	"Create the local directory for SqueakMap."

	dir _ directoryName.
	(FileDirectory default directoryExists: dir)
		ifFalse:[FileDirectory default createDirectory: dir].
	fileCache _ SMFileCache newFor: self.
	checkpointNumber _ 1.
	daysBacklog _ 182. "about 6 months"