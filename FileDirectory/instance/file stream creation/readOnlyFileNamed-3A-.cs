readOnlyFileNamed: localFileName
	"Open the existing file with the given name in this directory for read-only access."

	^ StandardFileStream readOnlyFileNamed: (self fullNameFor: localFileName)
