onFileNamed: fileName
	"Answer an instance of me on a newly created file with the given name."

	| file |
	file _ (FileStream newFileNamed: fileName) binary.
	^ self new setStream: file
