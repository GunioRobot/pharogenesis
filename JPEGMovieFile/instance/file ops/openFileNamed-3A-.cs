openFileNamed: fileName
	"Open the JPEG movie file with the given name."

	file ifNotNil: [file finalize].
	file := nil.
	(FileDirectory default fileExists: fileName) ifFalse: [^ self].
	file := (FileStream readOnlyFileNamed: fileName) binary.
	self readHeader.
	currentFrameIndex := 1.
