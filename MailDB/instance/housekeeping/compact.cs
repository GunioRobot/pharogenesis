compact
	"Compact the message file and rebuild the index file. Answer an array containing with the number of messages and the number of bytes recovered."

	| newMessageFile newIndexFile stats |
	newMessageFile _ MessageFile openOn: rootFilename, '.messages.tmp'.
	newIndexFile _ IndexFile openOn: rootFilename, '.index.tmp' messageFile: newMessageFile.
	stats _ self copyUndeletedTo: newMessageFile indexFile: newIndexFile.
	newMessageFile save.
	newIndexFile save.
	messageFile rename: rootFilename, '.messages.bak'.
	indexFile rename: rootFilename, '.index.bak'.
	newMessageFile rename: rootFilename, '.messages'.
	newIndexFile rename: rootFilename, '.index'.
	indexFile delete.
	messageFile delete.
	indexFile _ newIndexFile.
	messageFile _ newMessageFile.
	self cleanUpCategories.
	categoriesFile save.
	^stats