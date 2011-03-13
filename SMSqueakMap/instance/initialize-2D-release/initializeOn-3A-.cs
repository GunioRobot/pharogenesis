initializeOn: directoryName
	"Create the local directory for SqueakMap."

	dir := directoryName.
	(FileDirectory default directoryExists: dir)
		ifFalse:[FileDirectory default createDirectory: dir].
	fileCache := SMFileCache newFor: self.
	checkpointNumber := 1