deleteFileNamed: localFileName ifAbsent: failBlock
	"Delete the file of the given name if it exists, else evaluate failBlock."

	(self primDeleteFileNamed: (self fullNameFor: localFileName)) == nil
		ifTrue: [^ failBlock value].
