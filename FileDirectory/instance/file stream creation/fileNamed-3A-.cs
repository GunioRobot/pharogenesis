fileNamed: localFileName
	"Open the file with the given name in this directory for writing."

	^ StandardFileStream fileNamed: (self fullNameFor: localFileName)
