newFile: fileName block: aBlock
	"Create a new file. Let <aBlock> fill the file with content by calling it with a stream."

	| dir stream |
	dir _ self uploadsDirectory.
	[(dir fileExists: fileName) ifTrue:[dir deleteFileNamed: fileName].
	stream _ dir newFileNamed: fileName.
	aBlock value: stream] ensure: [stream close]