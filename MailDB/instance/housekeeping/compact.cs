compact
	"Compact the message file and rebuild the index file. Answer an array  
	containing with the number of messages and the number of bytes  
	recovered."
	| newMessageFile newIndexFile stats |
	newMessageFile _ MessageFile openOn: rootFilename , '.messages.tmp'.
	"don't read log file here!"
	newIndexFile _ IndexFile
				openOn: rootFilename , '.index.tmp'
				messageFile: newMessageFile
				readLogFlag: false.
	stats _ self copyUndeletedTo: newMessageFile indexFile: newIndexFile.
	newMessageFile save.
	newIndexFile save.
	messageFile rename: rootFilename , '.messages.bak'.
	indexFile rename: rootFilename , '.index.bak'.
	newMessageFile rename: rootFilename , '.messages'.
	newIndexFile rename: rootFilename , '.index'.
	indexFile delete.
	messageFile delete.
	messageFile _ MessageFile openOn: rootFilename , '.messages'.
	"update messageFile in IndexFile entries by clean reopen of indexFile"
	indexFile _ IndexFile
				openOn: rootFilename , '.index'
				messageFile: messageFile
				readLogFlag: true.
	self cleanUpCategories.
	categoriesFile save.
	^ stats