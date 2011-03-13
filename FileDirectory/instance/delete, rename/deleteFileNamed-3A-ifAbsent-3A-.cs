deleteFileNamed: aFileName ifAbsent: failBlock
	"Delete the file of the given name if it exists, else evaluate failBlock"
	(self deleteFileNamed: aFileName) == nil ifTrue: [^ failBlock value]