newFileNamed: localFileName
	"Create a new file with the given name in this directory."

	^ StandardFileStream newFileNamed: (self fullNameFor: localFileName)
